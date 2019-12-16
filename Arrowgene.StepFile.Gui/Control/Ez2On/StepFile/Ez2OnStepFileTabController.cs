using Arrowgene.Services.Buffers;
using Arrowgene.Services.Extra;
using Arrowgene.StepFile.Gui.Control.Tab;
using Arrowgene.StepFile.Gui.Core;
using Arrowgene.StepFile.Gui.Core.Ez2On.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Arrowgene.StepFile.Gui.Control.Ez2On.StepFile
{
    public class Ez2OnStepFileTabController : TabController
    {
        private Ez2OnStepFileTabControl _ez2OnStepFileTabControl;

        public Ez2OnStepFileTabController() : base(new Ez2OnStepFileTabControl())
        {
            _ez2OnStepFileTabControl = TabUserControl as Ez2OnStepFileTabControl;

            Header = "Ez2On StepFile";

            _ez2OnStepFileTabControl.OpenCommand = new CommandHandler(Open, true);
            _ez2OnStepFileTabControl.SaveCommand = new CommandHandler(Save, true);
            _ez2OnStepFileTabControl.Pt2EzCommand = new CommandHandler(Pt2EzCommand, true);
            _ez2OnStepFileTabControl.Pt2EzFolderCommand = new CommandHandler(Pt2EzFolderCommand, true);
        }
        private void Open()
        {
            FileInfo selected = new SelectFileBuilder()
                .Filter("Ez2On StepFile(*.ptn) | *.ptn")
                .SelectSingle();
            if (selected == null)
            {
                return;
            }
        }

        private void Save()
        {

        }

        private void Pt2EzCommand()
        {
            FileInfo ptFile = new SelectFileBuilder()
                .Filter("Pt File(*.pt) | *.pt")
                .SelectSingle();
            if (ptFile == null)
            {
                return;
            }
            Tuple<byte[], byte[]> result = ConvertPt2Ez(ptFile);



            string suggestedFileName = ptFile.Name.Replace(ptFile.Extension, "");
            FileInfo ezFile = new SaveFileBuilder()
                .FileName(suggestedFileName)
                .Filter("Ez file(*.ez) | *.ez")
                .Select();
            if (ezFile == null)
            {
                return;
            }
            string ezFilePath = ezFile.FullName;
            string eziFilePath = ezFilePath.Replace(".ez", ".ezi");
            Utils.WriteFile(result.Item1, ezFilePath);
            Utils.WriteFile(result.Item2, eziFilePath);

            MessageBox.Show($"Ez File Saved: {ezFile.FullName}", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Pt2EzFolderCommand()
        {
            MessageBox.Show($"Select PT Source", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
            DirectoryInfo selectedSource = new SelectFolderBuilder().Select();
            if (selectedSource == null)
            {
                return;
            }

            MessageBox.Show($"Select EZ Destination", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
            DirectoryInfo selectedDestination = new SelectFolderBuilder().Select();
            if (selectedDestination == null)
            {
                return;
            }

            FileInfo[] ptFiles = selectedSource.GetFiles("*.pt", SearchOption.TopDirectoryOnly);
            foreach (FileInfo ptFile in ptFiles)
            {
                Tuple<byte[], byte[]> result = ConvertPt2Ez(ptFile);
                string suggestedFileName = ptFile.Name.Replace(ptFile.Extension, ".ez");
                string ezFilePath = Path.Combine(selectedDestination.FullName, suggestedFileName);
                string eziFilePath = ezFilePath.Replace(".ez", ".ezi");
                Utils.WriteFile(result.Item1, ezFilePath);
                Utils.WriteFile(result.Item2, eziFilePath);
            }


            MessageBox.Show($"Saved: {ptFiles.Length} to: {selectedDestination.FullName}", "StepFile", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private Tuple<byte[], byte[]> ConvertPt2Ez(FileInfo ptFile)
        {
            IBuffer ptBuffer = new StreamBuffer(ptFile.FullName);
            ptBuffer.SetPositionStart();
            string header = ptBuffer.ReadCString();
            if (header != "PTFF")
            {
                MessageBox.Show($"Invalid .pt file: {ptFile.FullName}", "StepFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            byte unknown = ptBuffer.ReadByte();
            uint unknown1 = ptBuffer.ReadUInt32();
            uint unknown2 = ptBuffer.ReadUInt32();
            uint unknown3 = ptBuffer.ReadUInt32();
            uint unknown4 = ptBuffer.ReadUInt32();
            uint oggSections = ptBuffer.ReadUInt16();
            List<PtSoundEntry> entries = new List<PtSoundEntry>();
            for (int i = 0; i < oggSections; i++)
            {
                PtSoundEntry entry = new PtSoundEntry();
                entry.Id = ptBuffer.ReadUInt16();
                entry.OggFile = ptBuffer.ReadFixedString(14);
                entry.Unknown5 = ptBuffer.ReadUInt32();
                entry.Unknown6 = ptBuffer.ReadUInt32();
                entry.Unknown7 = ptBuffer.ReadUInt32();
                entry.Unknown8 = ptBuffer.ReadUInt32();
                entry.Unknown9 = ptBuffer.ReadUInt32();
                entry.Unknown10 = ptBuffer.ReadUInt32();
                entry.Unknown11 = ptBuffer.ReadUInt32();
                entry.Unknown12 = ptBuffer.ReadUInt32();
                entry.Unknown13 = ptBuffer.ReadUInt32();
                entry.Unknown14 = ptBuffer.ReadUInt32();
                entry.Unknown15 = ptBuffer.ReadUInt32();
                entry.Unknown16 = ptBuffer.ReadUInt32();
                entry.Unknown17 = ptBuffer.ReadUInt16();
                entries.Add(entry);
            }
            byte[] eztrData = ptBuffer.ReadBytes(ptBuffer.Size - ptBuffer.Position);

            IBuffer ezBuffer = new StreamBuffer();
            ezBuffer.WriteCString("EZFF");
            ezBuffer.WriteByte(unknown);
            ezBuffer.WriteBytes(new byte[128]);
            ezBuffer.WriteInt32(unknown1);
            ezBuffer.WriteInt32(unknown2);
            ezBuffer.WriteInt32(unknown3);
            ezBuffer.WriteInt32(unknown4);
            ezBuffer.WriteBytes(eztrData);


            IBuffer eziBuffer = new StreamBuffer();
            int idx = 0;
            foreach (PtSoundEntry ptSound in entries)
            {
                string prefix = GetEziPrefix(idx);
                if (prefix == null)
                {
                    break;
                }
                eziBuffer.WriteString($"{prefix} {ptSound.OggFile}\r\n");
                idx++;
            }

            return new Tuple<byte[], byte[]>(ezBuffer.GetAllBytes(), eziBuffer.GetAllBytes());
        }


        private string GetEziPrefix(int index)
        {
            if(index == 0)
            {
                return $"C#0 1";
            }
            index++;
            int note = index % 12;
            int noteNumber = index / 12;
            switch (note)
            {
                case 0: return $"C{noteNumber} 0";
                case 1: return $"C#{noteNumber} 0";
                case 2: return $"D{noteNumber} 0";
                case 3: return $"D#{noteNumber} 0";
                case 4: return $"E{noteNumber} 0";
                case 5: return $"F{noteNumber} 0";
                case 6: return $"F#{noteNumber} 0";
                case 7: return $"G{noteNumber} 0";
                case 8: return $"G#{noteNumber} 0";
                case 9: return $"A{noteNumber} 0";
                case 10: return $"A#{noteNumber} 0";
                case 11: return $"B{noteNumber} 0";
            }
            return null;
        }


    }
}
