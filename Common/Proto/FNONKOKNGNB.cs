// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: FNONKOKNGNB.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from FNONKOKNGNB.proto</summary>
  public static partial class FNONKOKNGNBReflection {

    #region Descriptor
    /// <summary>File descriptor for FNONKOKNGNB.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FNONKOKNGNBReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFGTk9OS09LTkdOQi5wcm90byJMCgtGTk9OS09LTkdOQhITCgtGT0dGSUdD",
            "RUpLTxgDIAEoDRITCgtFSkhMSkZESE5QSRgKIAEoDRITCgtBTEdCSFBLTURG",
            "QxgEIAEoDUIeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlByb3RvYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.FNONKOKNGNB), global::EggLink.DanhengServer.Proto.FNONKOKNGNB.Parser, new[]{ "FOGFIGCEJKO", "EJHLJFDHNPI", "ALGBHPKMDFC" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class FNONKOKNGNB : pb::IMessage<FNONKOKNGNB>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FNONKOKNGNB> _parser = new pb::MessageParser<FNONKOKNGNB>(() => new FNONKOKNGNB());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FNONKOKNGNB> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.FNONKOKNGNBReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FNONKOKNGNB() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FNONKOKNGNB(FNONKOKNGNB other) : this() {
      fOGFIGCEJKO_ = other.fOGFIGCEJKO_;
      eJHLJFDHNPI_ = other.eJHLJFDHNPI_;
      aLGBHPKMDFC_ = other.aLGBHPKMDFC_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FNONKOKNGNB Clone() {
      return new FNONKOKNGNB(this);
    }

    /// <summary>Field number for the "FOGFIGCEJKO" field.</summary>
    public const int FOGFIGCEJKOFieldNumber = 3;
    private uint fOGFIGCEJKO_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint FOGFIGCEJKO {
      get { return fOGFIGCEJKO_; }
      set {
        fOGFIGCEJKO_ = value;
      }
    }

    /// <summary>Field number for the "EJHLJFDHNPI" field.</summary>
    public const int EJHLJFDHNPIFieldNumber = 10;
    private uint eJHLJFDHNPI_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint EJHLJFDHNPI {
      get { return eJHLJFDHNPI_; }
      set {
        eJHLJFDHNPI_ = value;
      }
    }

    /// <summary>Field number for the "ALGBHPKMDFC" field.</summary>
    public const int ALGBHPKMDFCFieldNumber = 4;
    private uint aLGBHPKMDFC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ALGBHPKMDFC {
      get { return aLGBHPKMDFC_; }
      set {
        aLGBHPKMDFC_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FNONKOKNGNB);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FNONKOKNGNB other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (FOGFIGCEJKO != other.FOGFIGCEJKO) return false;
      if (EJHLJFDHNPI != other.EJHLJFDHNPI) return false;
      if (ALGBHPKMDFC != other.ALGBHPKMDFC) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (FOGFIGCEJKO != 0) hash ^= FOGFIGCEJKO.GetHashCode();
      if (EJHLJFDHNPI != 0) hash ^= EJHLJFDHNPI.GetHashCode();
      if (ALGBHPKMDFC != 0) hash ^= ALGBHPKMDFC.GetHashCode();
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
      if (FOGFIGCEJKO != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(FOGFIGCEJKO);
      }
      if (ALGBHPKMDFC != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(ALGBHPKMDFC);
      }
      if (EJHLJFDHNPI != 0) {
        output.WriteRawTag(80);
        output.WriteUInt32(EJHLJFDHNPI);
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
      if (FOGFIGCEJKO != 0) {
        output.WriteRawTag(24);
        output.WriteUInt32(FOGFIGCEJKO);
      }
      if (ALGBHPKMDFC != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(ALGBHPKMDFC);
      }
      if (EJHLJFDHNPI != 0) {
        output.WriteRawTag(80);
        output.WriteUInt32(EJHLJFDHNPI);
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
      if (FOGFIGCEJKO != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(FOGFIGCEJKO);
      }
      if (EJHLJFDHNPI != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(EJHLJFDHNPI);
      }
      if (ALGBHPKMDFC != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ALGBHPKMDFC);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FNONKOKNGNB other) {
      if (other == null) {
        return;
      }
      if (other.FOGFIGCEJKO != 0) {
        FOGFIGCEJKO = other.FOGFIGCEJKO;
      }
      if (other.EJHLJFDHNPI != 0) {
        EJHLJFDHNPI = other.EJHLJFDHNPI;
      }
      if (other.ALGBHPKMDFC != 0) {
        ALGBHPKMDFC = other.ALGBHPKMDFC;
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
          case 24: {
            FOGFIGCEJKO = input.ReadUInt32();
            break;
          }
          case 32: {
            ALGBHPKMDFC = input.ReadUInt32();
            break;
          }
          case 80: {
            EJHLJFDHNPI = input.ReadUInt32();
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
          case 24: {
            FOGFIGCEJKO = input.ReadUInt32();
            break;
          }
          case 32: {
            ALGBHPKMDFC = input.ReadUInt32();
            break;
          }
          case 80: {
            EJHLJFDHNPI = input.ReadUInt32();
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