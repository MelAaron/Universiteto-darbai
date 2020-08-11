BEGIN{
	max1 = 0;
	max2 = 0;
	max3 = 0;
}
{
	if($1 > max1) max1 = $1;
	if($2 > max2) max2 = $2;
	if($3 > max3) max3 = $3;
}
END{
	print max1" " max2" " max3
}
