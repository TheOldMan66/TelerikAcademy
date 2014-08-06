using System;

namespace CohesionAndCoupling
{
    class FileNames
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int extensionLength = GetFileExtension(fileName).Length;
            string onlyFileName = fileName;
            if (extensionLength != 0)
            {
                onlyFileName = fileName.Remove(fileName.Length - extensionLength - 1);
            }

            return onlyFileName;
        }
    }
}
