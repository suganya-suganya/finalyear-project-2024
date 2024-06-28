using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DiffieHellmanMerkle
{
    internal sealed class CryptoPrimitives
    {

        public static bool SUCCESS_STATUS(uint status)
        {
            bool returnVal = false;

            //success
            if (status >= 0 || status <= 0x3FFFFFFF)
            returnVal = true;

            //information
        if (status >= 0x40000000 || status <= 0x7FFFFFFF)
            returnVal = true;

            return returnVal;
        }

        [DllImport("Bcrypt.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint BCryptOpenAlgorithmProvider(
            ref IntPtr hAlgorithm,
            string AlgId,
            string Implementation,
            uint Flags
            );

        [DllImport("Bcrypt.dll", SetLastError = true)]
        public static extern uint BCryptGenerateKeyPair(
            IntPtr hObject,
            ref IntPtr hKey,
            uint length,
            uint Flags
            );


        [DllImport("Bcrypt.dll", SetLastError = true)]
        public static extern uint BCryptFinalizeKeyPair(
            IntPtr hKey,
            uint Flags
            );


        [DllImport("Bcrypt.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint BCryptExportKey(
            IntPtr hKey,
            IntPtr hExportKey,
            string BlobType,
            byte[] pbOutput,
            uint OutputByteLength,
            out uint Result,
            uint Flags
            );


        [DllImport("Bcrypt.dll", SetLastError = true)]
        public static extern uint BCryptDestroyKey(
            IntPtr hKey
            );

        [DllImport("Bcrypt.dll", SetLastError = true)]
        public static extern uint BCryptCloseAlgorithmProvider(
            IntPtr hAlgorithm,
            uint Flags
            );

        [DllImport("Bcrypt.dll", SetLastError = true)]
        public static extern uint BCryptDestroySecret(
            IntPtr hSecretAgreement
            );


        [DllImport("Bcrypt.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint BCryptImportKeyPair(
            IntPtr hAlgorithm,
            IntPtr hImportKey,
            string BlobType,
            ref IntPtr hPublicKey,
            byte[] Input,
            uint InputByteLength,
            uint Flags
            );

        [DllImport("Bcrypt.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint BCryptSecretAgreement(
            IntPtr hPrivKey,
            IntPtr hPublicKey,
            ref IntPtr phSecret,
            uint Flags
            );

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public class BCryptBufferDesc
        {
            public uint ulVersion;
            public uint cBuffers;
            public IntPtr pBuffers;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class BCryptBuffer
        {
            public uint cbBuffer;
            public uint BufferType;
            public IntPtr pvBuffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BCRYPT_ECCKEY_BLOB 
        {  
            uint Magic;  
            uint cbKey;
        } 


        [DllImport("Bcrypt.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint BCryptDeriveKey(
            IntPtr hSharedSecret,
            string KDF,
            BCryptBufferDesc ParameterList,
            byte[] DerivedKey,
            uint DerivedKeyByteSize,
            out uint Result,
            uint Flags
            );
    }
}
