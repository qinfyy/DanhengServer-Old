// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: EACGDHHGNOK.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from EACGDHHGNOK.proto</summary>
  public static partial class EACGDHHGNOKReflection {

    #region Descriptor
    /// <summary>File descriptor for EACGDHHGNOK.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EACGDHHGNOKReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFFQUNHREhIR05PSy5wcm90bxoRSExBQURPUEVPSUUucHJvdG8aEUZDSUZN",
            "TUpORkJOLnByb3RvGhFHREJERElPRkJOSi5wcm90byJ2CgtFQUNHREhIR05P",
            "SxIhCgtDQkVLRUNDSk1FTBgLIAEoCzIMLkhMQUFET1BFT0lFEiEKC09IQkxO",
            "QkhMTUhGGAggASgLMgwuRkNJRk1NSk5GQk4SIQoLTENJSERMRUREQ04YBSAB",
            "KAsyDC5HREJERElPRkJOSkIeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlBy",
            "b3RvYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.HLAADOPEOIEReflection.Descriptor, global::EggLink.DanhengServer.Proto.FCIFMMJNFBNReflection.Descriptor, global::EggLink.DanhengServer.Proto.GDBDDIOFBNJReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.EACGDHHGNOK), global::EggLink.DanhengServer.Proto.EACGDHHGNOK.Parser, new[]{ "CBEKECCJMEL", "OHBLNBHLMHF", "LCIHDLEDDCN" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class EACGDHHGNOK : pb::IMessage<EACGDHHGNOK>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EACGDHHGNOK> _parser = new pb::MessageParser<EACGDHHGNOK>(() => new EACGDHHGNOK());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<EACGDHHGNOK> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.EACGDHHGNOKReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EACGDHHGNOK() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EACGDHHGNOK(EACGDHHGNOK other) : this() {
      cBEKECCJMEL_ = other.cBEKECCJMEL_ != null ? other.cBEKECCJMEL_.Clone() : null;
      oHBLNBHLMHF_ = other.oHBLNBHLMHF_ != null ? other.oHBLNBHLMHF_.Clone() : null;
      lCIHDLEDDCN_ = other.lCIHDLEDDCN_ != null ? other.lCIHDLEDDCN_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public EACGDHHGNOK Clone() {
      return new EACGDHHGNOK(this);
    }

    /// <summary>Field number for the "CBEKECCJMEL" field.</summary>
    public const int CBEKECCJMELFieldNumber = 11;
    private global::EggLink.DanhengServer.Proto.HLAADOPEOIE cBEKECCJMEL_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.HLAADOPEOIE CBEKECCJMEL {
      get { return cBEKECCJMEL_; }
      set {
        cBEKECCJMEL_ = value;
      }
    }

    /// <summary>Field number for the "OHBLNBHLMHF" field.</summary>
    public const int OHBLNBHLMHFFieldNumber = 8;
    private global::EggLink.DanhengServer.Proto.FCIFMMJNFBN oHBLNBHLMHF_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.FCIFMMJNFBN OHBLNBHLMHF {
      get { return oHBLNBHLMHF_; }
      set {
        oHBLNBHLMHF_ = value;
      }
    }

    /// <summary>Field number for the "LCIHDLEDDCN" field.</summary>
    public const int LCIHDLEDDCNFieldNumber = 5;
    private global::EggLink.DanhengServer.Proto.GDBDDIOFBNJ lCIHDLEDDCN_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.GDBDDIOFBNJ LCIHDLEDDCN {
      get { return lCIHDLEDDCN_; }
      set {
        lCIHDLEDDCN_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as EACGDHHGNOK);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(EACGDHHGNOK other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(CBEKECCJMEL, other.CBEKECCJMEL)) return false;
      if (!object.Equals(OHBLNBHLMHF, other.OHBLNBHLMHF)) return false;
      if (!object.Equals(LCIHDLEDDCN, other.LCIHDLEDDCN)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (cBEKECCJMEL_ != null) hash ^= CBEKECCJMEL.GetHashCode();
      if (oHBLNBHLMHF_ != null) hash ^= OHBLNBHLMHF.GetHashCode();
      if (lCIHDLEDDCN_ != null) hash ^= LCIHDLEDDCN.GetHashCode();
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
      if (lCIHDLEDDCN_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(LCIHDLEDDCN);
      }
      if (oHBLNBHLMHF_ != null) {
        output.WriteRawTag(66);
        output.WriteMessage(OHBLNBHLMHF);
      }
      if (cBEKECCJMEL_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(CBEKECCJMEL);
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
      if (lCIHDLEDDCN_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(LCIHDLEDDCN);
      }
      if (oHBLNBHLMHF_ != null) {
        output.WriteRawTag(66);
        output.WriteMessage(OHBLNBHLMHF);
      }
      if (cBEKECCJMEL_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(CBEKECCJMEL);
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
      if (cBEKECCJMEL_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CBEKECCJMEL);
      }
      if (oHBLNBHLMHF_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OHBLNBHLMHF);
      }
      if (lCIHDLEDDCN_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(LCIHDLEDDCN);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(EACGDHHGNOK other) {
      if (other == null) {
        return;
      }
      if (other.cBEKECCJMEL_ != null) {
        if (cBEKECCJMEL_ == null) {
          CBEKECCJMEL = new global::EggLink.DanhengServer.Proto.HLAADOPEOIE();
        }
        CBEKECCJMEL.MergeFrom(other.CBEKECCJMEL);
      }
      if (other.oHBLNBHLMHF_ != null) {
        if (oHBLNBHLMHF_ == null) {
          OHBLNBHLMHF = new global::EggLink.DanhengServer.Proto.FCIFMMJNFBN();
        }
        OHBLNBHLMHF.MergeFrom(other.OHBLNBHLMHF);
      }
      if (other.lCIHDLEDDCN_ != null) {
        if (lCIHDLEDDCN_ == null) {
          LCIHDLEDDCN = new global::EggLink.DanhengServer.Proto.GDBDDIOFBNJ();
        }
        LCIHDLEDDCN.MergeFrom(other.LCIHDLEDDCN);
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
          case 42: {
            if (lCIHDLEDDCN_ == null) {
              LCIHDLEDDCN = new global::EggLink.DanhengServer.Proto.GDBDDIOFBNJ();
            }
            input.ReadMessage(LCIHDLEDDCN);
            break;
          }
          case 66: {
            if (oHBLNBHLMHF_ == null) {
              OHBLNBHLMHF = new global::EggLink.DanhengServer.Proto.FCIFMMJNFBN();
            }
            input.ReadMessage(OHBLNBHLMHF);
            break;
          }
          case 90: {
            if (cBEKECCJMEL_ == null) {
              CBEKECCJMEL = new global::EggLink.DanhengServer.Proto.HLAADOPEOIE();
            }
            input.ReadMessage(CBEKECCJMEL);
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
          case 42: {
            if (lCIHDLEDDCN_ == null) {
              LCIHDLEDDCN = new global::EggLink.DanhengServer.Proto.GDBDDIOFBNJ();
            }
            input.ReadMessage(LCIHDLEDDCN);
            break;
          }
          case 66: {
            if (oHBLNBHLMHF_ == null) {
              OHBLNBHLMHF = new global::EggLink.DanhengServer.Proto.FCIFMMJNFBN();
            }
            input.ReadMessage(OHBLNBHLMHF);
            break;
          }
          case 90: {
            if (cBEKECCJMEL_ == null) {
              CBEKECCJMEL = new global::EggLink.DanhengServer.Proto.HLAADOPEOIE();
            }
            input.ReadMessage(CBEKECCJMEL);
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