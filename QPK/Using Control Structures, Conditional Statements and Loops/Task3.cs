//ORIGINAL:
int i = 0;
for (i = 0; i < 100;) 
{
   if (i % 10 == 0)
   {
   	Console.WriteLine(array[i]);
   	if ( array[i] == expectedValue ) 
   	{
   	   i = 666;
   	}
   	i++;
   }
   else
   {
        Console.WriteLine(array[i]);
   	i++;
   }
}
// More code here
if (i == 666)
{
    Console.WriteLine("Value Found");
}

//REFACTORED:

bool valueIsFound = false;

for (i = 0; i < 100; i++) 
{
    Console.WriteLine(array[i]);
    if (i % 10 == 0 && array[i] == expectedValue) 
      {
        valueIsFound = true;
        break;
      }
}
// More code here
if (valueIsFound)
{
   Console.WriteLine("Value Found");
}

