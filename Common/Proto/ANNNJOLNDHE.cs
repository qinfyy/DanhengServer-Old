// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ANNNJOLNDHE.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from ANNNJOLNDHE.proto</summary>
  public static partial class ANNNJOLNDHEReflection {

    #region Descriptor
    /// <summary>File descriptor for ANNNJOLNDHE.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ANNNJOLNDHEReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFBTk5OSk9MTkRIRS5wcm90bxoRRk5CS0dBSUdOREIucHJvdG8iSgoLQU5O",
            "TkpPTE5ESEUSIQoLSUdJSUdMSkhQSUEYDSADKAsyDC5GTkJLR0FJR05EQhIY",
            "ChByb2d1ZV92ZXJzaW9uX2lkGAIgASgNQh6qAhtFZ2dMaW5rLkRhbmhlbmdT",
            "ZXJ2ZXIuUHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.FNBKGAIGNDBReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.ANNNJOLNDHE), global::EggLink.DanhengServer.Proto.ANNNJOLNDHE.Parser, new[]{ "IGIIGLJHPIA", "RogueVersionId" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class ANNNJOLNDHE : pb::IMessage<ANNNJOLNDHE>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ANNNJOLNDHE> _parser = new pb::MessageParser<ANNNJOLNDHE>(() => new ANNNJOLNDHE());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ANNNJOLNDHE> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.ANNNJOLNDHEReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ANNNJOLNDHE() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ANNNJOLNDHE(ANNNJOLNDHE other) : this() {
      iGIIGLJHPIA_ = other.iGIIGLJHPIA_.Clone();
      rogueVersionId_ = other.rogueVersionId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ANNNJOLNDHE Clone() {
      return new ANNNJOLNDHE(this);
    }

    /// <summary>Field number for the "IGIIGLJHPIA" field.</summary>
    public const int IGIIGLJHPIAFieldNumber = 13;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.FNBKGAIGNDB> _repeated_iGIIGLJHPIA_codec
        = pb::FieldCodec.ForMessage(106, global::EggLink.DanhengServer.Proto.FNBKGAIGNDB.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.FNBKGAIGNDB> iGIIGLJHPIA_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.FNBKGAIGNDB>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.FNBKGAIGNDB> IGIIGLJHPIA {
      get { return iGIIGLJHPIA_; }
    }

    /// <summary>Field number for the "rogue_version_id" field.</summary>
    public const int RogueVersionIdFieldNumber = 2;
    private uint rogueVersionId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint RogueVersionId {
      get { return rogueVersionId_; }
      set {
        rogueVersionId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ANNNJOLNDHE);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ANNNJOLNDHE other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!iGIIGLJHPIA_.Equals(other.iGIIGLJHPIA_)) return false;
      if (RogueVersionId != other.RogueVersionId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= iGIIGLJHPIA_.GetHashCode();
      if (RogueVersionId != 0) hash ^= RogueVersionId.GetHashCode();
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
      if (RogueVersionId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(RogueVersionId);
      }
      iGIIGLJHPIA_.WriteTo(output, _repeated_iGIIGLJHPIA_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (RogueVersionId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(RogueVersionId);
      }
      iGIIGLJHPIA_.WriteTo(ref output, _repeated_iGIIGLJHPIA_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += iGIIGLJHPIA_.CalculateSize(_repeated_iGIIGLJHPIA_codec);
      if (RogueVersionId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(RogueVersionId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ANNNJOLNDHE other) {
      if (other == null) {
        return;
      }
      iGIIGLJHPIA_.Add(other.iGIIGLJHPIA_);
      if (other.RogueVersionId != 0) {
        RogueVersionId = other.RogueVersionId;
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
          case 16: {
            RogueVersionId = input.ReadUInt32();
            break;
          }
          case 106: {
            iGIIGLJHPIA_.AddEntriesFrom(input, _repeated_iGIIGLJHPIA_codec);
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
          case 16: {
            RogueVersionId = input.ReadUInt32();
            break;
          }
          case 106: {
            iGIIGLJHPIA_.AddEntriesFrom(ref input, _repeated_iGIIGLJHPIA_codec);
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