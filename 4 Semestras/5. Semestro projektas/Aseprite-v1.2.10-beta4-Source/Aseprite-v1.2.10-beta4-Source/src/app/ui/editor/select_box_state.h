// Aseprite
// Copyright (C) 2001-2018  David Capello
//
// This program is distributed under the terms of
// the End-User License Agreement for Aseprite.

#ifndef APP_UI_EDITOR_SELECT_BOX_STATE_H_INCLUDED
#define APP_UI_EDITOR_SELECT_BOX_STATE_H_INCLUDED
#pragma once

#include "app/ui/editor/editor_decorator.h"
#include "app/ui/editor/ruler.h"
#include "app/ui/editor/standby_state.h"
#include "ui/cursor_type.h"
#include "ui/mouse_buttons.h"

#include <string>
#include <vector>

namespace app {

  class SelectBoxDelegate {
  public:
    virtual ~SelectBoxDelegate() { }

    // Called each time the selected box is modified (e.g. rulers are
    // moved).
    virtual void onChangeRectangle(const gfx::Rect& rect) { }

    // Called only in QUICKBOX mode, when the user released the mouse
    // button.
    virtual void onQuickboxEnd(Editor* editor, const gfx::Rect& rect, ui::MouseButtons buttons) { }
    virtual void onQuickboxCancel(Editor* editor) { }

    // Help text to be shown in the ContextBar
    virtual std::string onGetContextBarHelp() { return ""; }
  };

  class SelectBoxState : public StandbyState
                       , public EditorDecorator {
    enum { H1, H2, V1, V2 };

  public:
    enum class Flags {
      // Draw rulers at each edge of the current box
      Rulers = 1,

      // The outside of the current box must be darker (used in "Canvas Size" command)
      DarkOutside = 2,

      // Show a horizontal array of boxes starting from the current box
      HGrid = 4,

      // Show a vertical array of boxes starting from the current box
      VGrid = 8,

      // Show a grid starting from the current box
      Grid = (HGrid | VGrid),

      // Select the box as in selection tool, drawing a boxu
      QuickBox = 16,
    };

    SelectBoxState(SelectBoxDelegate* delegate,
                   const gfx::Rect& rc,
                   Flags flags);
    ~SelectBoxState();

    void setFlags(Flags flags);

    // Returns the bounding box arranged by the rulers.
    gfx::Rect getBoxBounds() const;
    void setBoxBounds(const gfx::Rect& rc);

    // EditorState overrides
    virtual void onEnterState(Editor* editor) override;
    virtual void onBeforePopState(Editor* editor) override;
    virtual bool onMouseDown(Editor* editor, ui::MouseMessage* msg) override;
    virtual bool onMouseUp(Editor* editor, ui::MouseMessage* msg) override;
    virtual bool onMouseMove(Editor* editor, ui::MouseMessage* msg) override;
    virtual bool onSetCursor(Editor* editor, const gfx::Point& mouseScreenPos) override;
    virtual bool acceptQuickTool(tools::Tool* tool) override;
    virtual bool requireBrushPreview() override;
    virtual tools::Ink* getStateInk() override;

    // EditorDecorator overrides
    virtual void postRenderDecorator(EditorPostRender* render) override;
    virtual void getInvalidDecoratoredRegion(Editor* editor, gfx::Region& region) override;

  private:
    typedef std::vector<Ruler> Rulers;

    void updateContextBar();

    // This returns a ui align value (e.g. LEFT for the ruler)
    int hitTestRulers(Editor* editor,
                      const gfx::Point& mousePos,
                      const bool updateMovingRulers);

    // Returns true if the position screen position (x, y) is touching
    // the given ruler.
    bool hitTestRuler(Editor* editor, const Ruler& ruler,
                      const gfx::Point& mousePos);

    ui::CursorType cursorFromAlign(const int align) const;

    bool hasFlag(Flags flag) const;

    SelectBoxDelegate* m_delegate;
    Rulers m_rulers;
    Rulers m_startRulers;
    int m_rulersDragAlign;      // Used to calculate the correct mouse cursor
    std::vector<int> m_movingRulers;
    bool m_selectingBox;
    ui::MouseButtons m_selectingButtons;
    gfx::Point m_startingPos;
    Flags m_flags;
  };

} // namespace app

#endif  // APP_UI_EDITOR_SELECT_BOX_STATE_H_INCLUDED