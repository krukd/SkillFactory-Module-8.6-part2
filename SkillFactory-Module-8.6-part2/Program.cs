namespace SkillFactory_Module_8._6_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string dirName = "\\\\Mac\\Home\\Desktop\\ВКР.Итог";

            
            if (Directory.Exists(dirName)) 
            { 
            try
            {
                DirectoryInfo myDir = new DirectoryInfo(dirName);

                long totalSum;

                totalSum = TotalSizeMainFolder(myDir, 0); 

                Console.WriteLine($"Total volume {totalSum} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
           
        }
           
        }

        static long TotalSizeMainFolder(DirectoryInfo dir, long r_vol) 
        {
            long r_sum = r_vol;
            FileInfo[] r_fileArr = dir.GetFiles();
            for (int i = 0; i < r_fileArr.Length; i++)
            {
                
                r_sum += r_fileArr[i].Length;
            }

            Console.WriteLine("Files of the directory - " + dir.FullName);
            Console.WriteLine("Volume - " + r_sum + " bytes");

            DirectoryInfo[] dirArr = dir.GetDirectories();
            r_sum += TotalSizeSubfolder(dirArr, r_sum); 

            return r_sum;
        }

       
        static long TotalSizeSubfolder(DirectoryInfo[] workDir, long vol) 
        {
            long sum = vol;

            for (int i = 0; i < workDir.Length; i++)
            {

                FileInfo[] fileArr = workDir[i].GetFiles();
                for (int j = 0; j < fileArr.Length; j++)
                {
                    
                    sum += fileArr[j].Length;
                }
                Console.WriteLine("Files of the directory " + workDir[i].FullName);
                Console.WriteLine("Volume " + sum + " bytes");
                sum += TotalSizeSubfolder(workDir[i].GetDirectories(), sum); 
            }
            return sum;
        }

    }
}