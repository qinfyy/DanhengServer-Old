// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: OLHCHMPLJPE.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from OLHCHMPLJPE.proto</summary>
  public static partial class OLHCHMPLJPEReflection {

    #region Descriptor
    /// <summary>File descriptor for OLHCHMPLJPE.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OLHCHMPLJPEReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFPTEhDSE1QTEpQRS5wcm90bxoRR0VPRkpJRUdBREoucHJvdG8aEVBESUJJ",
            "S0VDSUtHLnByb3RvIlMKC09MSENITVBMSlBFEiEKC3Jldml2ZV9pbmZvGAYg",
            "ASgLMgwuR0VPRkpJRUdBREoSIQoLUEdOTlBOREtKQUoYDCADKAsyDC5QRElC",
            "SUtFQ0lLR0IeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlByb3RvYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.GEOFJIEGADJReflection.Descriptor, global::EggLink.DanhengServer.Proto.PDIBIKECIKGReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.OLHCHMPLJPE), global::EggLink.DanhengServer.Proto.OLHCHMPLJPE.Parser, new[]{ "ReviveInfo", "PGNNPNDKJAJ" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class OLHCHMPLJPE : pb::IMessage<OLHCHMPLJPE>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<OLHCHMPLJPE> _parser = new pb::MessageParser<OLHCHMPLJPE>(() => new OLHCHMPLJPE());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<OLHCHMPLJPE> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.OLHCHMPLJPEReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OLHCHMPLJPE() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OLHCHMPLJPE(OLHCHMPLJPE other) : this() {
      reviveInfo_ = other.reviveInfo_ != null ? other.reviveInfo_.Clone() : null;
      pGNNPNDKJAJ_ = other.pGNNPNDKJAJ_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public OLHCHMPLJPE Clone() {
      return new OLHCHMPLJPE(this);
    }

    /// <summary>Field number for the "revive_info" field.</summary>
    public const int ReviveInfoFieldNumber = 6;
    private global::EggLink.DanhengServer.Proto.GEOFJIEGADJ reviveInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.GEOFJIEGADJ ReviveInfo {
      get { return reviveInfo_; }
      set {
        reviveInfo_ = value;
      }
    }

    /// <summary>Field number for the "PGNNPNDKJAJ" field.</summary>
    public const int PGNNPNDKJAJFieldNumber = 12;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.PDIBIKECIKG> _repeated_pGNNPNDKJAJ_codec
        = pb::FieldCodec.ForMessage(98, global::EggLink.DanhengServer.Proto.PDIBIKECIKG.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.PDIBIKECIKG> pGNNPNDKJAJ_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.PDIBIKECIKG>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.PDIBIKECIKG> PGNNPNDKJAJ {
      get { return pGNNPNDKJAJ_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as OLHCHMPLJPE);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(OLHCHMPLJPE other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ReviveInfo, other.ReviveInfo)) return false;
      if(!pGNNPNDKJAJ_.Equals(other.pGNNPNDKJAJ_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (reviveInfo_ != null) hash ^= ReviveInfo.GetHashCode();
      hash ^= pGNNPNDKJAJ_.GetHashCode();
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
      if (reviveInfo_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(ReviveInfo);
      }
      pGNNPNDKJAJ_.WriteTo(output, _repeated_pGNNPNDKJAJ_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (reviveInfo_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(ReviveInfo);
      }
      pGNNPNDKJAJ_.WriteTo(ref output, _repeated_pGNNPNDKJAJ_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (reviveInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReviveInfo);
      }
      size += pGNNPNDKJAJ_.CalculateSize(_repeated_pGNNPNDKJAJ_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(OLHCHMPLJPE other) {
      if (other == null) {
        return;
      }
      if (other.reviveInfo_ != null) {
        if (reviveInfo_ == null) {
          ReviveInfo = new global::EggLink.DanhengServer.Proto.GEOFJIEGADJ();
        }
        ReviveInfo.MergeFrom(other.ReviveInfo);
      }
      pGNNPNDKJAJ_.Add(other.pGNNPNDKJAJ_);
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
          case 50: {
            if (reviveInfo_ == null) {
              ReviveInfo = new global::EggLink.DanhengServer.Proto.GEOFJIEGADJ();
            }
            input.ReadMessage(ReviveInfo);
            break;
          }
          case 98: {
            pGNNPNDKJAJ_.AddEntriesFrom(input, _repeated_pGNNPNDKJAJ_codec);
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
          case 50: {
            if (reviveInfo_ == null) {
              ReviveInfo = new global::EggLink.DanhengServer.Proto.GEOFJIEGADJ();
            }
            input.ReadMessage(ReviveInfo);
            break;
          }
          case 98: {
            pGNNPNDKJAJ_.AddEntriesFrom(ref input, _repeated_pGNNPNDKJAJ_codec);
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