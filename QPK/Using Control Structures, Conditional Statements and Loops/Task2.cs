//ORIGINAL:
Potato potato;
//... 
if (potato != null)
{
   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
	Cook(potato);
}



if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
{
   VisitCell();
}

//REFACTORED:
bool potatoPresent = potato != null;
bool potatoIsPeeled = !potato.HasNotBeenPeeled;
bool potatoIsFresh = !potato.IsRotten;

if (potatoPresent && potatoIsPeeled && potatoIsFresh)
{
	Cook(potato);
}



bool cellIsInRange = (MIN_X <= x) && (x <= MAX_X); 
cellIsInRange = cellIsInRange && (MIN_Y <= y) && ( y <= MAX_Y );
bool mustVisitCell = !shouldNotVisitCell;

if (cellIsInRange &&  mustVisitCell)
{
   VisitCell();
}
