namespace Advent
{
    public static class Day1
    {

        public static int GetDistance(string filePath)
        {
            var (leftList, rightList) = ParseInput(filePath);
            leftList.Sort();
            rightList.Sort();
            return leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();
        }

        public static int GetSimilarityScore(string filePath)
        {
            var (leftList, rightList) = ParseInput(filePath);
            var similarity = 0;
            leftList.ForEach(num =>
            {
                similarity += num * rightList.FindAll(curNum => curNum == num).Count;
            });
            return similarity;
        }
        public static (List<int>, List<int>) ParseInput(string filePath)
        {
            List<int> leftList = new();
            List<int> rightList = new();
            string? line = "";
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                line = streamReader.ReadLine();
                while (line != null)
                {
                    if (line != null)
                    {
                        var splitLine = line.Split("   ");
                        if (int.TryParse(splitLine[0], out int num1))
                        {
                            leftList.Add(num1);
                        }
                        if (int.TryParse(splitLine[1], out int num2))
                        {
                            rightList.Add(num2);
                        }
                        line = streamReader.ReadLine();

                    }
                }
                streamReader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file" + e.Message);
            }
            return (leftList, rightList);
        }
    }

}