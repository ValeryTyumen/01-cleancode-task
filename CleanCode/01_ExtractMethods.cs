using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string line, byte[] data)
		{
			var fileStream1 = new FileStream(line, FileMode.OpenOrCreate);
		    string changeExtension = Path.ChangeExtension(line, "bkp");
		    var fileStream2 = new FileStream(changeExtension, FileMode.OpenOrCreate);

			WriteData(data, fileStream1, fileStream2);

		    CloseFiles(fileStream1, fileStream2);

			SaveLastWriteTime(line);
		}

	    private static void SaveLastWriteTime(string line)
	    {
	        string path = line + ".time";
	        var fileStream3 = new FileStream(path, FileMode.OpenOrCreate);
	        var time = BitConverter.GetBytes(DateTime.Now.Ticks);
	        fileStream3.Write(time, 0, time.Length);
	        fileStream3.Close();
	    }

	    private static void CloseFiles(FileStream fileStream1, FileStream fileStream2)
	    {
	        fileStream1.Close();
	        fileStream2.Close();
	    }

	    private static void WriteData(byte[] data, FileStream fileStream1, FileStream fileStream2)
	    {
	        fileStream1.Write(data, 0, data.Length);
	        fileStream2.Write(data, 0, data.Length);
	    }
	}
}