using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DiffieHellmanMerkle
{
    public sealed class ECDiffieHellmanMerkle
    {
        private readonly string PUBLIC_BLOB = "ECCPUBLICBLOB";
        private readonly uint KDF_HASH_ALGORITHM = 0x0;
        private readonly uint BCRYPTBUFFER_VERSION = 0;
        private readonly uint KDF_USE_SECRET_AS_HMAC_KEY_FLAG = 0x1;
        private ECDHKeyDerivationFunction KDF = ECDHKeyDerivationFunction.HASH;
        private DerivedKeyHashAlgorithm HASH = DerivedKeyHashAlgorithm.SHA1_ALGORITHM;

        IntPtr _hAlgorithmProvider = new IntPtr();
        IntPtr _hPrivateKey = new IntPtr();
        uint _publicKeyByteSize = 0;
        byte[] _publicKey;
        IntPtr _hSecretAgreement = new IntPtr();
        
        public byte[] PublicKey
        {
            get { return _publicKey; }
        }

        public ECDHKeyDerivationFunction KeyDerivationFunction
        {
            get { return KDF; }
            set { KDF = value; }
        }

        public DerivedKeyHashAlgorithm HashAlgorithm
        {
            get { return HASH; }
            set { HASH = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ECDiffieHellmanMerkle"/> class.
        /// </summary>
        public ECDiffieHellmanMerkle():this(ECDHAlgorithm.ECDH_256)
        {
        }

        ~ECDiffieHellmanMerkle()
        {
            CryptoPrimitives.BCryptCloseAlgorithmProvider(_hAlgorithmProvider, 0);
            CryptoPrimitives.BCryptDestroyKey(_hPrivateKey);
            CryptoPrimitives.BCryptDestroySecret(_hSecretAgreement);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ECDiffieHellmanMerkle"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        public ECDiffieHellmanMerkle(ECDHAlgorithm algorithm)
        {
            string _ECDHAlgorithmString;
            uint _ECDHAlgorithmStrength;
            uint status=0;
            //set required algorithm string value
            //and bit length
            switch (algorithm)
            {
                case ECDHAlgorithm.ECDH_256:
                    _ECDHAlgorithmString = "ECDH_P256";
                    _ECDHAlgorithmStrength = 256;
                    break;
                case ECDHAlgorithm.ECDH_384:
                    _ECDHAlgorithmString = "ECDH_P384";
                    _ECDHAlgorithmStrength = 384;
                    break;
                case ECDHAlgorithm.ECDH_521:
                    _ECDHAlgorithmString = "ECDH_P521";
                    _ECDHAlgorithmStrength = 521;
                    break;
                default:
                    _ECDHAlgorithmString = "ECDH_P256";
                    _ECDHAlgorithmStrength = 256;
                    break;
            }
            try
            {
                //open algorithm provider pointer _hAlgorithmProvider
                status =CryptoPrimitives.BCryptOpenAlgorithmProvider(ref _hAlgorithmProvider, _ECDHAlgorithmString, null, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //create private key pointer _hPrivateKey
                status = CryptoPrimitives.BCryptGenerateKeyPair(_hAlgorithmProvider, ref _hPrivateKey, _ECDHAlgorithmStrength, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //necessary final step to create public/private key
                status = CryptoPrimitives.BCryptFinalizeKeyPair(_hPrivateKey, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //call BCryptExportKey with null parameter to find size of public key
                status = CryptoPrimitives.BCryptExportKey(_hPrivateKey, IntPtr.Zero, PUBLIC_BLOB, null, 0, out _publicKeyByteSize, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //set aside memory for public key
                _publicKey = new byte[_publicKeyByteSize];
                //call BCryptExportKey again to create public key as byte array
                status = CryptoPrimitives.BCryptExportKey(_hPrivateKey, IntPtr.Zero, PUBLIC_BLOB, _publicKey, _publicKeyByteSize, out _publicKeyByteSize, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
            }
            catch
            {
                CryptoPrimitives.BCryptCloseAlgorithmProvider(_hAlgorithmProvider, 0);
                CryptoPrimitives.BCryptDestroyKey(_hPrivateKey);
                throw new Win32Exception();

            }
        }


        /// <summary>
        /// Retrieves the secret key.
        /// </summary>
        /// <param name="externalPublicKey">The public key received from partner.</param>
        /// <returns></returns>
        public byte[] RetrieveSecretKey(byte[] externalPublicKey)
        {
            string keyDerivationFunction;
            uint keyDerivationFlagValue;
            switch(KDF)
            {
                case ECDHKeyDerivationFunction.HMAC:
                    keyDerivationFunction = "HMAC";
                    keyDerivationFlagValue = KDF_USE_SECRET_AS_HMAC_KEY_FLAG;
                    break;
                default:
                    keyDerivationFunction = "HASH";
                    keyDerivationFlagValue = 0;
                    break;
            }
            
            byte[] _secretKey = new Byte[0];
            uint derivedSecretByteSize;
            string KDFHash;
            switch (HASH)
            {
                case DerivedKeyHashAlgorithm.SHA1_ALGORITHM:
                    KDFHash = "SHA1";
                    break;
                case DerivedKeyHashAlgorithm.SHA256_ALGORITHM:
                    KDFHash = "SHA256";
                    break;
                case DerivedKeyHashAlgorithm.SHA384_ALGORITHM:
                    KDFHash = "SHA384";
                    break;
                case DerivedKeyHashAlgorithm.SHA512_ALGORITHM:
                    KDFHash = "SHA512";
                    break;
                default:
                    KDFHash = "SHA1";
                    break;
            }
            //create parameters for hash type
            CryptoPrimitives.BCryptBuffer bcBuffer = new CryptoPrimitives.BCryptBuffer();
            bcBuffer.BufferType = KDF_HASH_ALGORITHM;
            bcBuffer.cbBuffer = (uint)((KDFHash.Length * 2) + 2);
            IntPtr pvBuffer = Marshal.AllocHGlobal(KDFHash.Length * 2);
            Marshal.Copy(KDFHash.ToCharArray(), 0, pvBuffer, KDFHash.Length);
            bcBuffer.pvBuffer = pvBuffer;

            CryptoPrimitives.BCryptBufferDesc parameters = new CryptoPrimitives.BCryptBufferDesc();
            parameters.cBuffers = 1;
            parameters.ulVersion = BCRYPTBUFFER_VERSION;
            parameters.pBuffers = Marshal.AllocHGlobal(Marshal.SizeOf(bcBuffer));
            Marshal.StructureToPtr(bcBuffer, parameters.pBuffers, false);


            uint status=0;
            try
            {
                //discover public key size
                uint publicKeyByteSize = (uint)externalPublicKey.Length;
                //get pointer to public key
                IntPtr publicKeyHandle = Marshal.AllocHGlobal((int)publicKeyByteSize);
                status = CryptoPrimitives.BCryptImportKeyPair(_hAlgorithmProvider, IntPtr.Zero, PUBLIC_BLOB, ref publicKeyHandle, externalPublicKey, publicKeyByteSize, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //create pointer to secret agreement from private key and external public key
                status = CryptoPrimitives.BCryptSecretAgreement(_hPrivateKey, publicKeyHandle, ref _hSecretAgreement, 0);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //call BCryptDeriveKey with null parameter to find size of secret key
                if (KDFHash == "SHA1")
                    status = CryptoPrimitives.BCryptDeriveKey(_hSecretAgreement, keyDerivationFunction, null, null, 0, out derivedSecretByteSize, keyDerivationFlagValue);
                else
                    status = CryptoPrimitives.BCryptDeriveKey(_hSecretAgreement, keyDerivationFunction, parameters, null, 0, out derivedSecretByteSize, keyDerivationFlagValue);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
                //set aside memory for secret key
                _secretKey = new byte[derivedSecretByteSize];
                //create a secret key as byte array from secret agreement
                if (KDFHash == "SHA1")
                    status = CryptoPrimitives.BCryptDeriveKey(_hSecretAgreement, keyDerivationFunction, null, _secretKey, derivedSecretByteSize, out derivedSecretByteSize, keyDerivationFlagValue);
                else
                    status = CryptoPrimitives.BCryptDeriveKey(_hSecretAgreement, keyDerivationFunction, parameters, _secretKey, derivedSecretByteSize, out derivedSecretByteSize, keyDerivationFlagValue);
                if (!CryptoPrimitives.SUCCESS_STATUS(status))
                    throw new Exception();
            }
            catch
            {
                    throw new Win32Exception();
            }
            finally
            {
                CryptoPrimitives.BCryptCloseAlgorithmProvider(_hAlgorithmProvider, 0);
                CryptoPrimitives.BCryptDestroyKey(_hPrivateKey);
                CryptoPrimitives.BCryptDestroySecret(_hSecretAgreement);
            }
            return _secretKey;
        }
    }

    public enum ECDHAlgorithm
    {
        ECDH_256 = 256,// = "ECDH_P256";
        ECDH_384 = 384,// = "ECDH_P384";
        ECDH_521 = 521 // "ECDH_P521";
    }

    public enum ECDHKeyDerivationFunction
    {
        HASH,
        HMAC
    }

    public enum DerivedKeyHashAlgorithm
    {
        SHA1_ALGORITHM,//= "SHA1"
        SHA256_ALGORITHM,//="SHA256"
        SHA384_ALGORITHM,//="SHA384"
        SHA512_ALGORITHM,//="SHA512"
    }
}
