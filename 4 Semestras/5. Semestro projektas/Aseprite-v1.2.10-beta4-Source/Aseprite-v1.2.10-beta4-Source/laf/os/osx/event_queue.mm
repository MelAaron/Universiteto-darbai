// LAF OS Library
// Copyright (C) 2018  Igara Studio S.A.
// Copyright (C) 2015-2017  David Capello
//
// This file is released under the terms of the MIT license.
// Read LICENSE.txt for more information.

#ifdef HAVE_CONFIG_H
#include "config.h"
#endif

#include <Cocoa/Cocoa.h>
#include <Carbon/Carbon.h>

#include "os/osx/event_queue.h"

#define EV_TRACE(...)

namespace os {

void OSXEventQueue::getEvent(Event& ev, bool canWait)
{
  ev.setType(Event::None);

  @autoreleasepool {
    NSApplication* app = [NSApplication sharedApplication];
    if (!app)
      return;

    NSEvent* event;
    do {
      // Pump the whole queue of Cocoa events
      event = [app nextEventMatchingMask:NSEventMaskAny
                               untilDate:[NSDate distantPast]
                                  inMode:NSDefaultRunLoopMode
                                 dequeue:YES];
    retry:
      if (event) {
        // Intercept <Control+Tab>, <Cmd+[>, and other keyboard
        // combinations, and send them directly to the main
        // NSView. Without this, the NSApplication intercepts the key
        // combination and use it to go to the next key view.
        if (event.type == NSEventTypeKeyDown) {
          [app.mainWindow.contentView keyDown:event];
        }
        else {
          [app sendEvent:event];
        }
      }
    } while (event);

    if (!m_events.try_pop(ev)) {
      if (canWait) {
        EV_TRACE("EV: Wait for events...\n");

        // Wait until there is a Cocoa event in queue
        m_sleeping = true;
        event = [app nextEventMatchingMask:NSEventMaskAny
                                 untilDate:[NSDate distantFuture]
                                    inMode:NSDefaultRunLoopMode
                                   dequeue:YES];
        m_sleeping = false;

        EV_TRACE("EV: Wake up!\n");
        goto retry;
      }
    }
  }
}

void OSXEventQueue::queueEvent(const Event& ev)
{
  if (m_sleeping) {
    // Wake up the macOS event queue. This is necessary in case that we
    // change the display color profile from macOS settings: the
    // display surface is regenerated with the new color space, a
    // Event::ResizeDisplay event is enqueued and we have to start
    // processing macOS events again. If we don't wake up the events
    // queue, the window keeps with a black background and is not
    // re-painted until we receive some event from the OS, like a
    // mouse movement.
    wakeUpQueue();
    m_sleeping = false;
  }
  m_events.push(ev);
}

void OSXEventQueue::wakeUpQueue()
{
  @autoreleasepool {
    NSApplication* app = [NSApplication sharedApplication];
    if (!app)
      return;
    [app postEvent:[NSEvent otherEventWithType:NSApplicationDefined
                                      location:NSZeroPoint
                                 modifierFlags:0
                                     timestamp:0
                                  windowNumber:0
                                       context:nullptr
                                       subtype:0
                                         data1:0
                                         data2:0]
           atStart:NO];
  }
}

} // namespace os
