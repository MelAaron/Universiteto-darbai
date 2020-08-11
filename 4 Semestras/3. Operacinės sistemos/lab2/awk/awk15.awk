BEGIN{
print "Pradzia";
FS = ":";
paketai=0;
baitai=0;
}
{
paketai = paketai + $5;
baitai = baitai +$6;
}
END{
print paketai " " baitai;
}
