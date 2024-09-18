using System.Security.Cryptography;

for(int i = 0; i < 500; i++)
{
    Console.WriteLine(GenerateSecureOTP());
}


int GenerateSecureOTP()
{
    int MinValue = 100000;
    int MaxValue = 999999;

    int OTP = RandomNumberGenerator.GetInt32(MinValue, MaxValue);
    return OTP;
}
