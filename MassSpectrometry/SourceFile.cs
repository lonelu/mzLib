﻿// Copyright 2012, 2013, 2014 Derek J. Bailey
// Modified work Copyright 2016 Stefan Solntsev
//
// This file (IMsDataFile.cs) is part of MassSpectrometry.
//
// MassSpectrometry is free software: you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MassSpectrometry is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
// License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with MassSpectrometry. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;

namespace MassSpectrometry
{
    public class SourceFile
    {
        #region Public Constructors

        public SourceFile(string nativeIdFormat, string massSpectrometerFileFormat, string checkSum, string fileChecksumType, string id)
        {
            NativeIdFormat = nativeIdFormat;
            MassSpectrometerFileFormat = massSpectrometerFileFormat;
            CheckSum = checkSum;
            FileChecksumType = fileChecksumType;
            Id = id;
        }

        public SourceFile(string nativeIdFormat, string massSpectrometerFileFormat, string checkSum, string fileChecksumType, string filePath, string id)
        : this(nativeIdFormat, massSpectrometerFileFormat, checkSum, fileChecksumType, id)
        {
            Uri.TryCreate(Directory.GetParent(filePath).FullName, UriKind.Absolute, out Uri result);
            this.Uri = result;
            this.FileName = Path.GetFileName(filePath);
        }

        public SourceFile(string nativeIdFormat, string massSpectrometerFileFormat, string checkSum, string fileChecksumType, Uri uri, string id, string fileName)
            : this(nativeIdFormat, massSpectrometerFileFormat, checkSum, fileChecksumType, id)
        {
            this.Uri = uri;
            this.FileName = fileName;
        }

        #endregion Public Constructors

        #region Public Properties

        public string NativeIdFormat { get; }
        public string MassSpectrometerFileFormat { get; }
        public string CheckSum { get; }
        public string FileChecksumType { get; }
        public Uri Uri { get; }

        public string FileName { get; }
        public string Id { get; }

        #endregion Public Properties
    }
}