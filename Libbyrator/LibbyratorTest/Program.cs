using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NAudio.Wave;

namespace LibbyratorTest;



internal static class Program {

	private static void Main() {

		string executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
		string projectDirectory = Directory.GetParent(executingDirectory)!.Parent!.Parent!.FullName;

		string sourcePath = Path.Combine(projectDirectory, "ASource");
		string targetPath = Path.Combine(projectDirectory, "ADestination");

		if (Directory.Exists(targetPath)) {
			Directory.Delete(targetPath, true);
		}
		Directory.CreateDirectory(targetPath);

		string[] sourceFilePaths = Directory.GetFiles(sourcePath, "", SearchOption.AllDirectories);
		FileInfo[] sourceFiles = sourceFilePaths.Select(x => new FileInfo(x)).ToArray();
		List<FileInfo> mp3Files = new();

		foreach (FileInfo sourceFile in sourceFiles) {

			try {
				MediaFoundationReader reader = new(sourceFile.FullName);
				mp3Files.Add(sourceFile);

			} catch (Exception exception) {
				bool test = false;
			}
		}

		foreach (FileInfo file in mp3Files) {
			
			// for some reason there are some duplicate files so they need to be over written.
			File.Copy(file.FullName, Path.Combine(targetPath, file.Name), true);

			Mp3FileReader reader = new(file.FullName);
			TimeSpan duration = reader.TotalTime;

			Console.WriteLine($"{file.FullName}, {file.Length / 1000000} MB, {duration}");
		}

		string[] filePaths = Directory.GetFiles(targetPath);
		FileInfo[] files = filePaths.Select(x => new FileInfo(x)).ToArray();


		foreach (FileInfo file in files) {

			byte[] contents = File.ReadAllBytes(file.FullName);
			File.WriteAllBytes($"{file.FullName}.mp3", contents);
			File.Delete(file.FullName);
		}
	}

}