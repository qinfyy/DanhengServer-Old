// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: HKHOIDMONOM.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from HKHOIDMONOM.proto</summary>
  public static partial class HKHOIDMONOMReflection {

    #region Descriptor
    /// <summary>File descriptor for HKHOIDMONOM.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HKHOIDMONOMReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFIS0hPSURNT05PTS5wcm90bxoRS0pKT0dQQ0FCTUgucHJvdG8aEUJPRFBH",
            "Q0pJQ0pBLnByb3RvGhFBRktJSkpHQUJJRy5wcm90byKzAQoLSEtIT0lETU9O",
            "T00SEwoLT01JREVGRUtNS0gYDSABKA0SEwoLR0pMTkFLREpDR0EYCSABKA0S",
            "EQoJY29uZmlnX2lkGAYgASgNEiEKC0RJQUpFRUNDSktDGAEgASgLMgwuQUZL",
            "SUpKR0FCSUcSIQoLSURPQkZFR0tMS1AYAiABKAsyDC5CT0RQR0NKSUNKQRIh",
            "CgtCS01ORUdNSkpCQxgLIAEoCzIMLktKSk9HUENBQk1IQh6qAhtFZ2dMaW5r",
            "LkRhbmhlbmdTZXJ2ZXIuUHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.KJJOGPCABMHReflection.Descriptor, global::EggLink.DanhengServer.Proto.BODPGCJICJAReflection.Descriptor, global::EggLink.DanhengServer.Proto.AFKIJJGABIGReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.HKHOIDMONOM), global::EggLink.DanhengServer.Proto.HKHOIDMONOM.Parser, new[]{ "OMIDEFEKMKH", "GJLNAKDJCGA", "ConfigId", "DIAJEECCJKC", "IDOBFEGKLKP", "BKMNEGMJJBC" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class HKHOIDMONOM : pb::IMessage<HKHOIDMONOM>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<HKHOIDMONOM> _parser = new pb::MessageParser<HKHOIDMONOM>(() => new HKHOIDMONOM());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<HKHOIDMONOM> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.HKHOIDMONOMReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public HKHOIDMONOM() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public HKHOIDMONOM(HKHOIDMONOM other) : this() {
      oMIDEFEKMKH_ = other.oMIDEFEKMKH_;
      gJLNAKDJCGA_ = other.gJLNAKDJCGA_;
      configId_ = other.configId_;
      dIAJEECCJKC_ = other.dIAJEECCJKC_ != null ? other.dIAJEECCJKC_.Clone() : null;
      iDOBFEGKLKP_ = other.iDOBFEGKLKP_ != null ? other.iDOBFEGKLKP_.Clone() : null;
      bKMNEGMJJBC_ = other.bKMNEGMJJBC_ != null ? other.bKMNEGMJJBC_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public HKHOIDMONOM Clone() {
      return new HKHOIDMONOM(this);
    }

    /// <summary>Field number for the "OMIDEFEKMKH" field.</summary>
    public const int OMIDEFEKMKHFieldNumber = 13;
    private uint oMIDEFEKMKH_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint OMIDEFEKMKH {
      get { return oMIDEFEKMKH_; }
      set {
        oMIDEFEKMKH_ = value;
      }
    }

    /// <summary>Field number for the "GJLNAKDJCGA" field.</summary>
    public const int GJLNAKDJCGAFieldNumber = 9;
    private uint gJLNAKDJCGA_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint GJLNAKDJCGA {
      get { return gJLNAKDJCGA_; }
      set {
        gJLNAKDJCGA_ = value;
      }
    }

    /// <summary>Field number for the "config_id" field.</summary>
    public const int ConfigIdFieldNumber = 6;
    private uint configId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ConfigId {
      get { return configId_; }
      set {
        configId_ = value;
      }
    }

    /// <summary>Field number for the "DIAJEECCJKC" field.</summary>
    public const int DIAJEECCJKCFieldNumber = 1;
    private global::EggLink.DanhengServer.Proto.AFKIJJGABIG dIAJEECCJKC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.AFKIJJGABIG DIAJEECCJKC {
      get { return dIAJEECCJKC_; }
      set {
        dIAJEECCJKC_ = value;
      }
    }

    /// <summary>Field number for the "IDOBFEGKLKP" field.</summary>
    public const int IDOBFEGKLKPFieldNumber = 2;
    private global::EggLink.DanhengServer.Proto.BODPGCJICJA iDOBFEGKLKP_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.BODPGCJICJA IDOBFEGKLKP {
      get { return iDOBFEGKLKP_; }
      set {
        iDOBFEGKLKP_ = value;
      }
    }

    /// <summary>Field number for the "BKMNEGMJJBC" field.</summary>
    public const int BKMNEGMJJBCFieldNumber = 11;
    private global::EggLink.DanhengServer.Proto.KJJOGPCABMH bKMNEGMJJBC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.KJJOGPCABMH BKMNEGMJJBC {
      get { return bKMNEGMJJBC_; }
      set {
        bKMNEGMJJBC_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as HKHOIDMONOM);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(HKHOIDMONOM other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OMIDEFEKMKH != other.OMIDEFEKMKH) return false;
      if (GJLNAKDJCGA != other.GJLNAKDJCGA) return false;
      if (ConfigId != other.ConfigId) return false;
      if (!object.Equals(DIAJEECCJKC, other.DIAJEECCJKC)) return false;
      if (!object.Equals(IDOBFEGKLKP, other.IDOBFEGKLKP)) return false;
      if (!object.Equals(BKMNEGMJJBC, other.BKMNEGMJJBC)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (OMIDEFEKMKH != 0) hash ^= OMIDEFEKMKH.GetHashCode();
      if (GJLNAKDJCGA != 0) hash ^= GJLNAKDJCGA.GetHashCode();
      if (ConfigId != 0) hash ^= ConfigId.GetHashCode();
      if (dIAJEECCJKC_ != null) hash ^= DIAJEECCJKC.GetHashCode();
      if (iDOBFEGKLKP_ != null) hash ^= IDOBFEGKLKP.GetHashCode();
      if (bKMNEGMJJBC_ != null) hash ^= BKMNEGMJJBC.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (dIAJEECCJKC_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(DIAJEECCJKC);
      }
      if (iDOBFEGKLKP_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(IDOBFEGKLKP);
      }
      if (ConfigId != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(ConfigId);
      }
      if (GJLNAKDJCGA != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(GJLNAKDJCGA);
      }
      if (bKMNEGMJJBC_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(BKMNEGMJJBC);
      }
      if (OMIDEFEKMKH != 0) {
        output.WriteRawTag(104);
        output.WriteUInt32(OMIDEFEKMKH);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (dIAJEECCJKC_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(DIAJEECCJKC);
      }
      if (iDOBFEGKLKP_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(IDOBFEGKLKP);
      }
      if (ConfigId != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(ConfigId);
      }
      if (GJLNAKDJCGA != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(GJLNAKDJCGA);
      }
      if (bKMNEGMJJBC_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(BKMNEGMJJBC);
      }
      if (OMIDEFEKMKH != 0) {
        output.WriteRawTag(104);
        output.WriteUInt32(OMIDEFEKMKH);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (OMIDEFEKMKH != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(OMIDEFEKMKH);
      }
      if (GJLNAKDJCGA != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(GJLNAKDJCGA);
      }
      if (ConfigId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ConfigId);
      }
      if (dIAJEECCJKC_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(DIAJEECCJKC);
      }
      if (iDOBFEGKLKP_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(IDOBFEGKLKP);
      }
      if (bKMNEGMJJBC_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(BKMNEGMJJBC);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(HKHOIDMONOM other) {
      if (other == null) {
        return;
      }
      if (other.OMIDEFEKMKH != 0) {
        OMIDEFEKMKH = other.OMIDEFEKMKH;
      }
      if (other.GJLNAKDJCGA != 0) {
        GJLNAKDJCGA = other.GJLNAKDJCGA;
      }
      if (other.ConfigId != 0) {
        ConfigId = other.ConfigId;
      }
      if (other.dIAJEECCJKC_ != null) {
        if (dIAJEECCJKC_ == null) {
          DIAJEECCJKC = new global::EggLink.DanhengServer.Proto.AFKIJJGABIG();
        }
        DIAJEECCJKC.MergeFrom(other.DIAJEECCJKC);
      }
      if (other.iDOBFEGKLKP_ != null) {
        if (iDOBFEGKLKP_ == null) {
          IDOBFEGKLKP = new global::EggLink.DanhengServer.Proto.BODPGCJICJA();
        }
        IDOBFEGKLKP.MergeFrom(other.IDOBFEGKLKP);
      }
      if (other.bKMNEGMJJBC_ != null) {
        if (bKMNEGMJJBC_ == null) {
          BKMNEGMJJBC = new global::EggLink.DanhengServer.Proto.KJJOGPCABMH();
        }
        BKMNEGMJJBC.MergeFrom(other.BKMNEGMJJBC);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (dIAJEECCJKC_ == null) {
              DIAJEECCJKC = new global::EggLink.DanhengServer.Proto.AFKIJJGABIG();
            }
            input.ReadMessage(DIAJEECCJKC);
            break;
          }
          case 18: {
            if (iDOBFEGKLKP_ == null) {
              IDOBFEGKLKP = new global::EggLink.DanhengServer.Proto.BODPGCJICJA();
            }
            input.ReadMessage(IDOBFEGKLKP);
            break;
          }
          case 48: {
            ConfigId = input.ReadUInt32();
            break;
          }
          case 72: {
            GJLNAKDJCGA = input.ReadUInt32();
            break;
          }
          case 90: {
            if (bKMNEGMJJBC_ == null) {
              BKMNEGMJJBC = new global::EggLink.DanhengServer.Proto.KJJOGPCABMH();
            }
            input.ReadMessage(BKMNEGMJJBC);
            break;
          }
          case 104: {
            OMIDEFEKMKH = input.ReadUInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (dIAJEECCJKC_ == null) {
              DIAJEECCJKC = new global::EggLink.DanhengServer.Proto.AFKIJJGABIG();
            }
            input.ReadMessage(DIAJEECCJKC);
            break;
          }
          case 18: {
            if (iDOBFEGKLKP_ == null) {
              IDOBFEGKLKP = new global::EggLink.DanhengServer.Proto.BODPGCJICJA();
            }
            input.ReadMessage(IDOBFEGKLKP);
            break;
          }
          case 48: {
            ConfigId = input.ReadUInt32();
            break;
          }
          case 72: {
            GJLNAKDJCGA = input.ReadUInt32();
            break;
          }
          case 90: {
            if (bKMNEGMJJBC_ == null) {
              BKMNEGMJJBC = new global::EggLink.DanhengServer.Proto.KJJOGPCABMH();
            }
            input.ReadMessage(BKMNEGMJJBC);
            break;
          }
          case 104: {
            OMIDEFEKMKH = input.ReadUInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code