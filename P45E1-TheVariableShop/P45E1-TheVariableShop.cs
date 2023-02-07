using System.Globalization;

byte smallestNumber = 255;
short smallNumber = 32767;
int number = 2_145_483_647;
long largeNumber = 9_223_372_036_854_775_807;

sbyte signedByte = -128;
ushort unsignedShort = 65535;
uint unsignedInteger = 4_294_967_295;
ulong unsignedLong = 18_446_744_073_709_551_615;

float muchAccurate = 14f;
double mucherAccurater = 15;
decimal veryAccurate = 13m;

char singleCharacter = 'A';
string arrayOfCharacters = "Allonsy!";

bool wasThisExcersizeUseful = false;

Console.WriteLine(smallestNumber + smallNumber + number + largeNumber);
Console.WriteLine(signedByte + unsignedShort + unsignedInteger + unsignedLong.ToString());
Console.WriteLine(muchAccurate + mucherAccurater.ToString() + veryAccurate);
Console.WriteLine(singleCharacter + arrayOfCharacters);
Console.WriteLine(wasThisExcersizeUseful);