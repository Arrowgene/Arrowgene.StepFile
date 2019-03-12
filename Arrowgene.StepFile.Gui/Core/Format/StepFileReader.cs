namespace Arrowgene.StepFile.Core.Format
{
    using Model;
    using System.Collections.Generic;
    using System.IO;
    using System;
    using Arrowgene.StepFile.Core.Format.Sim;

    /// <summary>
    /// Reader to read different stepfiles and create an object,
    /// that can then be used for further processing. 
    /// (e.g. write it as an different stepfile format to disk)
    /// </summary>
    public class StepFileReader
    {
        private Dictionary<string, IStepFileReader> stepFileReader;

        public static byte[] ReadFile(string filePath)
        {
            byte[] bytes = null;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fileStream.Length > Int32.MaxValue)
                {
                    throw new FileLoadException(string.Format("File size {0}bytes exceeds maximum length of {1}bytes", fileStream.Length, Int32.MaxValue), filePath);
                }

                int length = (int)fileStream.Length;
                bytes = new byte[length];
                fileStream.Read(bytes, 0, length);
            }
            return bytes;
        }

        /// <summary>
        /// Creates a new instance of the Class.
        /// </summary>
        public StepFileReader()
        {
            stepFileReader = new Dictionary<string, IStepFileReader>();
            stepFileReader.Add(".sm", new SimFileReader());
        }

        /// <summary>
        /// Add your own reader implemention.
        /// If you add a reader for an already existing file extension, 
        /// then the previous reader will be replaced by the newly provided one.
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <param name="reader"></param>
        public void AddReader(string fileExtension, IStepFileReader reader)
        {
            if (this.stepFileReader.ContainsKey(fileExtension))
            {
                this.stepFileReader[fileExtension] = reader;
            }
            else
            {
                this.stepFileReader.Add(fileExtension, reader);
            }
        }

        /// <summary>
        /// Returns a list of registered file extensions the reader can handle.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSupportedExtensions()
        {
            return this.stepFileReader.Keys;
        }

        /// <summary>
        /// Reads a file from the given path and 
        /// creates an <see cref="StpFile"/> object with the appropriate reader implementation.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public StpFile Read(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath);
            return this.Read(ReadFile(filePath), fileExtension);
        }

        public StpFile Read(byte[] file, string fileExtension)
        {
            StpFile stepFile = null;

            if (this.stepFileReader.ContainsKey(fileExtension))
            {
                stepFile = this.stepFileReader[fileExtension].Read(file);
            }

            return stepFile;
        }

    }
}