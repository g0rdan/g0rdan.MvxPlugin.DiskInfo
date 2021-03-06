﻿using System;
using Android.OS;

namespace g0rdan.MvvmCross.Plugin.DiskInfo.Droid
{
    public class DiskInfoPlugin : IDiskInfoPlugin
    {
        long _freeSpace;
        long _totalSpace;

        public decimal GetFreeSpace (StorageType storageType = StorageType.Inner, MemorySizeType mSizeType = MemorySizeType.Bytes, int digits = 2)
        {
            string path = storageType == StorageType.Inner ? 
                Android.OS.Environment.DataDirectory.Path : 
                Android.OS.Environment.ExternalStorageDirectory.Path;
            
            GetSizes(path);

            return ConvertTo (_freeSpace, mSizeType, digits);
        }

        public decimal GetTotalSpace (StorageType storageType = StorageType.Inner, MemorySizeType mSizeType = MemorySizeType.Bytes, int digits = 2)
        {
            string path = storageType == StorageType.Inner ? 
                Android.OS.Environment.DataDirectory.Path : 
                Android.OS.Environment.ExternalStorageDirectory.Path;

            GetSizes(path);

            return ConvertTo (_totalSpace, mSizeType, digits);
        }

        private void GetSizes(string path)
        {
            StatFs stat = new StatFs (path);
            _freeSpace = stat.AvailableBytes;
            _totalSpace = stat.TotalBytes;
        }

        private decimal ConvertTo (long bytes, MemorySizeType mSizeType, int digits)
        {
            decimal result;
            decimal divider = 1024;

            switch (mSizeType) {
            case MemorySizeType.KBytes:
                result = bytes / divider;
                break;
            case MemorySizeType.MBytes:
                result = bytes / divider / divider;
                break;
            case MemorySizeType.GBytes:
                result = bytes / divider / divider / divider;
                break;
            default:
                return bytes;
            }

            return Math.Round (result, digits);
        }
    }
}

