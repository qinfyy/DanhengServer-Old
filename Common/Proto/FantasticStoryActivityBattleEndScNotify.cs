// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: FantasticStoryActivityBattleEndScNotify.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from FantasticStoryActivityBattleEndScNotify.proto</summary>
  public static partial class FantasticStoryActivityBattleEndScNotifyReflection {

    #region Descriptor
    /// <summary>File descriptor for FantasticStoryActivityBattleEndScNotify.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FantasticStoryActivityBattleEndScNotifyReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci1GYW50YXN0aWNTdG9yeUFjdGl2aXR5QmF0dGxlRW5kU2NOb3RpZnkucHJv",
            "dG8iZgonRmFudGFzdGljU3RvcnlBY3Rpdml0eUJhdHRsZUVuZFNjTm90aWZ5",
            "EhEKCWJhdHRsZV9pZBgFIAEoDRITCgtMQ1BKR0NMSEVDTBgNIAEoDRITCgtL",
            "TlBGSktQTUhERhgLIAEoDUIeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlBy",
            "b3RvYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.FantasticStoryActivityBattleEndScNotify), global::EggLink.DanhengServer.Proto.FantasticStoryActivityBattleEndScNotify.Parser, new[]{ "BattleId", "LCPJGCLHECL", "KNPFJKPMHDF" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class FantasticStoryActivityBattleEndScNotify : pb::IMessage<FantasticStoryActivityBattleEndScNotify>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FantasticStoryActivityBattleEndScNotify> _parser = new pb::MessageParser<FantasticStoryActivityBattleEndScNotify>(() => new FantasticStoryActivityBattleEndScNotify());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FantasticStoryActivityBattleEndScNotify> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.FantasticStoryActivityBattleEndScNotifyReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FantasticStoryActivityBattleEndScNotify() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FantasticStoryActivityBattleEndScNotify(FantasticStoryActivityBattleEndScNotify other) : this() {
      battleId_ = other.battleId_;
      lCPJGCLHECL_ = other.lCPJGCLHECL_;
      kNPFJKPMHDF_ = other.kNPFJKPMHDF_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FantasticStoryActivityBattleEndScNotify Clone() {
      return new FantasticStoryActivityBattleEndScNotify(this);
    }

    /// <summary>Field number for the "battle_id" field.</summary>
    public const int BattleIdFieldNumber = 5;
    private uint battleId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint BattleId {
      get { return battleId_; }
      set {
        battleId_ = value;
      }
    }

    /// <summary>Field number for the "LCPJGCLHECL" field.</summary>
    public const int LCPJGCLHECLFieldNumber = 13;
    private uint lCPJGCLHECL_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint LCPJGCLHECL {
      get { return lCPJGCLHECL_; }
      set {
        lCPJGCLHECL_ = value;
      }
    }

    /// <summary>Field number for the "KNPFJKPMHDF" field.</summary>
    public const int KNPFJKPMHDFFieldNumber = 11;
    private uint kNPFJKPMHDF_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint KNPFJKPMHDF {
      get { return kNPFJKPMHDF_; }
      set {
        kNPFJKPMHDF_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FantasticStoryActivityBattleEndScNotify);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FantasticStoryActivityBattleEndScNotify other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BattleId != other.BattleId) return false;
      if (LCPJGCLHECL != other.LCPJGCLHECL) return false;
      if (KNPFJKPMHDF != other.KNPFJKPMHDF) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (BattleId != 0) hash ^= BattleId.GetHashCode();
      if (LCPJGCLHECL != 0) hash ^= LCPJGCLHECL.GetHashCode();
      if (KNPFJKPMHDF != 0) hash ^= KNPFJKPMHDF.GetHashCode();
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
      if (BattleId != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(BattleId);
      }
      if (KNPFJKPMHDF != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(KNPFJKPMHDF);
      }
      if (LCPJGCLHECL != 0) {
        output.WriteRawTag(104);
        output.WriteUInt32(LCPJGCLHECL);
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
      if (BattleId != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(BattleId);
      }
      if (KNPFJKPMHDF != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(KNPFJKPMHDF);
      }
      if (LCPJGCLHECL != 0) {
        output.WriteRawTag(104);
        output.WriteUInt32(LCPJGCLHECL);
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
      if (BattleId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(BattleId);
      }
      if (LCPJGCLHECL != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LCPJGCLHECL);
      }
      if (KNPFJKPMHDF != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(KNPFJKPMHDF);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FantasticStoryActivityBattleEndScNotify other) {
      if (other == null) {
        return;
      }
      if (other.BattleId != 0) {
        BattleId = other.BattleId;
      }
      if (other.LCPJGCLHECL != 0) {
        LCPJGCLHECL = other.LCPJGCLHECL;
      }
      if (other.KNPFJKPMHDF != 0) {
        KNPFJKPMHDF = other.KNPFJKPMHDF;
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
          case 40: {
            BattleId = input.ReadUInt32();
            break;
          }
          case 88: {
            KNPFJKPMHDF = input.ReadUInt32();
            break;
          }
          case 104: {
            LCPJGCLHECL = input.ReadUInt32();
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
          case 40: {
            BattleId = input.ReadUInt32();
            break;
          }
          case 88: {
            KNPFJKPMHDF = input.ReadUInt32();
            break;
          }
          case 104: {
            LCPJGCLHECL = input.ReadUInt32();
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