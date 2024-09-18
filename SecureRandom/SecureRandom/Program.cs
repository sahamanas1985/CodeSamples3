
using System.Security.Cryptography;




public class RandomOTPGenerator
{
    private const int MIN_LIMIT = 100000;
    private const int MAX_LIMIT = 999999;
    public int GenerateOTP()
    {
        return Generate(MIN_LIMIT, MAX_LIMIT);
    }
    private int Generate(int minLimit, int maxLimit)
    {
        int range = maxLimit - minLimit;
        byte[] randomNumber = new byte[4];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            int value = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue;
            return (value % range) + minLimit;
        }        
    }
}
