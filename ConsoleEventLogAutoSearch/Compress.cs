﻿//Written by Ceramicskate0
//Copyright 2018
using System;
using System.Text;
using System.IO;
using System.IO.Compression;


namespace SWELF
{
    internal class Compress
    {
        public static UTF8Encoding utfEncode = new UTF8Encoding();

        public static byte[] Compress_Contents_Byte(byte[] ToCompress)
        {
            byte[] bytesToCompress = ToCompress;

            using (MemoryStream memory = new MemoryStream(bytesToCompress))
            {
                using (DeflateStream compressionStream = new DeflateStream(memory, CompressionMode.Compress,false))
                {
                    compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                }
            }
            return bytesToCompress;
        }

        public static byte[] Compress_Contents_Byte(string ToCompress)
        {
            byte[] bytesToCompress = utfEncode.GetBytes(ToCompress);

            using (MemoryStream memory = new MemoryStream(bytesToCompress))
            {
                using (DeflateStream compressionStream = new DeflateStream(memory, CompressionMode.Compress,false))
                {
                    compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                }
            }
            return bytesToCompress;
        }

        public static string DeCompress_Contents_String(byte[] BytesToDecompress,int Size)
        {
            byte[] decompressedBytes = new byte[Size];

            using (MemoryStream memory = new MemoryStream(BytesToDecompress))
            {
                using (DeflateStream decompressionStream = new DeflateStream(memory, CompressionMode.Decompress,false))
                {
                    decompressionStream.Read(decompressedBytes, 0, Size);
                }
            }
            return utfEncode.GetString(decompressedBytes);
        }
    }
}
