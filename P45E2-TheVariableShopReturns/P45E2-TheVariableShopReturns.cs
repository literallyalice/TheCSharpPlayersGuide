using System.Globalization;

byte smallestNumber = 255;
smallestNumber = 254;
short smallNumber = 32767;
smallNumber = 3433;
int number = 2_145_483_647;
number = 3;
long largeNumber = 9_223_372_036_854_775_807;
largeNumber = 5;

sbyte signedByte = -128;
signedByte = 4;
ushort unsignedShort = 65535;
unsignedShort = 6;
uint unsignedInteger = 4_294_967_295;
unsignedInteger = 5;
ulong unsignedLong = 18_446_744_073_709_551_615;
unsignedLong = 43;

float muchAccurate = 14f;
muchAccurate = 15f;
double mucherAccurater = 15;
mucherAccurater = 16.44;
decimal veryAccurate = 13m;
veryAccurate = 123.555m;

char singleCharacter = 'A';
singleCharacter = '3';
string arrayOfCharacters = "Allonsy!";
arrayOfCharacters = "I'm The Doctor!";

bool wasThisExcersizeUseful = false;
wasThisExcersizeUseful = false; //Still useless

Console.WriteLine(smallestNumber + smallNumber + number + largeNumber);
Console.WriteLine(signedByte + unsignedShort + unsignedInteger + unsignedLong.ToString());
Console.WriteLine(muchAccurate + mucherAccurater.ToString() + veryAccurate);
Console.WriteLine(singleCharacter + arrayOfCharacters);
Console.WriteLine(wasThisExcersizeUseful);