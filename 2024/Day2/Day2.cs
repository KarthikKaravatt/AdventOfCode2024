namespace Advent
{
    public static class Day2
    {

        public static List<List<int>> ParseInput(string filePath)
        {
            List<List<int>> data = new();
            string line = "";
            try
            {
                StreamReader streamReader = new StreamReader(filePath);
                line = streamReader.ReadLine();
                while (line != null)
                {
                    List<int> row = new();
                    if (line != null)
                    {
                        var splitLine = line.Split(" ");
                        foreach (var item in splitLine)
                        {
                            if (int.TryParse(item, out int num))
                            {
                                row.Add(num);
                            }
                        }
                        data.Add(row);
                        line = streamReader.ReadLine();
                    }
                }
                streamReader.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file" + e.Message);
            }
            return data;
        }

        public static bool CheckSafe(List<int> data)
        {
            var acceding = (data[0] < data[data.Count - 1]);
            if (acceding)
            {
                int j = 0;
                for (int i = 1; i < data.Count; i++)
                {
                    int difference = data[i] - data[j];
                    if (data[i] < data[j])
                    {
                        return false;
                    }
                    else if (difference == 0 || difference > 3)
                    {
                        return false;
                    }
                    j++;
                }
            }
            else
            {
                int j = 0;
                for (int i = 1; i < data.Count; i++)
                {
                    int difference = data[j] - data[i];
                    if (data[i] > data[j])
                    {
                        return false;
                    }
                    else if (difference == 0 || difference > 3)
                    {
                        return false;
                    }
                    j++;
                }
            }
            return true;
        }

        public static bool CheckSafe2(List<int> data)
        {
            bool delete = false;
            bool acceding = data[1] > data[0];
            int j = 0;
            for (int i = 1; i < data.Count; i++)
            {
                if (acceding != data[i] > data[j])
                {
                    if (!delete)
                    {
                        data[i] = data[j];
                        delete = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                int difference = Math.Abs(data[i] - data[j]);
                if (difference > 3)
                {
                    if (!delete)
                    {
                        data[i] = data[j];
                        delete = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                j++;
            }
            return true;
        }
        public static int CountSafe(List<List<int>> data)
        {
            int count = 0;
            data.ForEach(item => { if (CheckSafe(item)) { count++; } });
            return count;
        }
        public static int CountSafe2(List<List<int>> data)
        {
            int count = 0;
            data.ForEach(item => { if (CheckSafe2(item)) { count++; } });
            return count;
        }
    }
}