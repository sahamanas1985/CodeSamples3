
namespace SortDemo
{
    public static class ExtTest
    {
        public static void GetArrayCounts(this char[] arrChar)
        {
            var GroupedChars = arrChar.GroupBy(x => x).Select(c => new { 
                Charname = c.Key,
                Count = c.Count()
            });

            foreach(var c in GroupedChars)
            {
                Console.WriteLine("Character: " + c.Charname + " - Count : " + c.Count);
            }

            // char[] uniqueChars = arrChar.Distinct().ToArray();
            // 
            //foreach(char c in uniqueChars)
            //{
            //    Console.WriteLine("Character: " + c + " - Count : " + arrChar.Where(i => i == c).Count());
            //}

        }
    }
}
