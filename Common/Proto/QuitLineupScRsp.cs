// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: QuitLineupScRsp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from QuitLineupScRsp.proto</summary>
  public static partial class QuitLineupScRspReflection {

    #region Descriptor
    /// <summary>File descriptor for QuitLineupScRsp.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static QuitLineupScRspReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVRdWl0TGluZXVwU2NSc3AucHJvdG8idQoPUXVpdExpbmV1cFNjUnNwEhAK",
            "CHBsYW5lX2lkGAIgASgNEg8KB3JldGNvZGUYCyABKA0SEwoLaXNfbWFpbmxp",
            "bmUYAyABKAgSEgoKaXNfdmlydHVhbBgMIAEoCBIWCg5iYXNlX2F2YXRhcl9p",
            "ZBgJIAEoDUIeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlByb3RvYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.QuitLineupScRsp), global::EggLink.DanhengServer.Proto.QuitLineupScRsp.Parser, new[]{ "PlaneId", "Retcode", "IsMainline", "IsVirtual", "BaseAvatarId" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class QuitLineupScRsp : pb::IMessage<QuitLineupScRsp>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<QuitLineupScRsp> _parser = new pb::MessageParser<QuitLineupScRsp>(() => new QuitLineupScRsp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<QuitLineupScRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.QuitLineupScRspReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuitLineupScRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuitLineupScRsp(QuitLineupScRsp other) : this() {
      planeId_ = other.planeId_;
      retcode_ = other.retcode_;
      isMainline_ = other.isMainline_;
      isVirtual_ = other.isVirtual_;
      baseAvatarId_ = other.baseAvatarId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QuitLineupScRsp Clone() {
      return new QuitLineupScRsp(this);
    }

    /// <summary>Field number for the "plane_id" field.</summary>
    public const int PlaneIdFieldNumber = 2;
    private uint planeId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint PlaneId {
      get { return planeId_; }
      set {
        planeId_ = value;
      }
    }

    /// <summary>Field number for the "retcode" field.</summary>
    public const int RetcodeFieldNumber = 11;
    private uint retcode_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Retcode {
      get { return retcode_; }
      set {
        retcode_ = value;
      }
    }

    /// <summary>Field number for the "is_mainline" field.</summary>
    public const int IsMainlineFieldNumber = 3;
    private bool isMainline_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsMainline {
      get { return isMainline_; }
      set {
        isMainline_ = value;
      }
    }

    /// <summary>Field number for the "is_virtual" field.</summary>
    public const int IsVirtualFieldNumber = 12;
    private bool isVirtual_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsVirtual {
      get { return isVirtual_; }
      set {
        isVirtual_ = value;
      }
    }

    /// <summary>Field number for the "base_avatar_id" field.</summary>
    public const int BaseAvatarIdFieldNumber = 9;
    private uint baseAvatarId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint BaseAvatarId {
      get { return baseAvatarId_; }
      set {
        baseAvatarId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as QuitLineupScRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(QuitLineupScRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (PlaneId != other.PlaneId) return false;
      if (Retcode != other.Retcode) return false;
      if (IsMainline != other.IsMainline) return false;
      if (IsVirtual != other.IsVirtual) return false;
      if (BaseAvatarId != other.BaseAvatarId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (PlaneId != 0) hash ^= PlaneId.GetHashCode();
      if (Retcode != 0) hash ^= Retcode.GetHashCode();
      if (IsMainline != false) hash ^= IsMainline.GetHashCode();
      if (IsVirtual != false) hash ^= IsVirtual.GetHashCode();
      if (BaseAvatarId != 0) hash ^= BaseAvatarId.GetHashCode();
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
      if (PlaneId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(PlaneId);
      }
      if (IsMainline != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsMainline);
      }
      if (BaseAvatarId != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(BaseAvatarId);
      }
      if (Retcode != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(Retcode);
      }
      if (IsVirtual != false) {
        output.WriteRawTag(96);
        output.WriteBool(IsVirtual);
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
      if (PlaneId != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(PlaneId);
      }
      if (IsMainline != false) {
        output.WriteRawTag(24);
        output.WriteBool(IsMainline);
      }
      if (BaseAvatarId != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(BaseAvatarId);
      }
      if (Retcode != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(Retcode);
      }
      if (IsVirtual != false) {
        output.WriteRawTag(96);
        output.WriteBool(IsVirtual);
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
      if (PlaneId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(PlaneId);
      }
      if (Retcode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Retcode);
      }
      if (IsMainline != false) {
        size += 1 + 1;
      }
      if (IsVirtual != false) {
        size += 1 + 1;
      }
      if (BaseAvatarId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(BaseAvatarId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(QuitLineupScRsp other) {
      if (other == null) {
        return;
      }
      if (other.PlaneId != 0) {
        PlaneId = other.PlaneId;
      }
      if (other.Retcode != 0) {
        Retcode = other.Retcode;
      }
      if (other.IsMainline != false) {
        IsMainline = other.IsMainline;
      }
      if (other.IsVirtual != false) {
        IsVirtual = other.IsVirtual;
      }
      if (other.BaseAvatarId != 0) {
        BaseAvatarId = other.BaseAvatarId;
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
            PlaneId = input.ReadUInt32();
            break;
          }
          case 24: {
            IsMainline = input.ReadBool();
            break;
          }
          case 72: {
            BaseAvatarId = input.ReadUInt32();
            break;
          }
          case 88: {
            Retcode = input.ReadUInt32();
            break;
          }
          case 96: {
            IsVirtual = input.ReadBool();
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
            PlaneId = input.ReadUInt32();
            break;
          }
          case 24: {
            IsMainline = input.ReadBool();
            break;
          }
          case 72: {
            BaseAvatarId = input.ReadUInt32();
            break;
          }
          case 88: {
            Retcode = input.ReadUInt32();
            break;
          }
          case 96: {
            IsVirtual = input.ReadBool();
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