// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ChessRogueCellInfo.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from ChessRogueCellInfo.proto</summary>
  public static partial class ChessRogueCellInfoReflection {

    #region Descriptor
    /// <summary>File descriptor for ChessRogueCellInfo.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ChessRogueCellInfoReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhDaGVzc1JvZ3VlQ2VsbEluZm8ucHJvdG8aDkNlbGxJbmZvLnByb3RvIoEB",
            "ChJDaGVzc1JvZ3VlQ2VsbEluZm8SEwoLSUVIS0JDTUZCRkIYBSABKA0SEwoL",
            "SkpNQUxLREVGR0UYCSABKA0SHAoJY2VsbF9saXN0GAYgAygLMgkuQ2VsbElu",
            "Zm8SEwoLREhGQkxFT09JTEQYASABKA0SDgoGY3VyX2lkGAcgASgNQh6qAhtF",
            "Z2dMaW5rLkRhbmhlbmdTZXJ2ZXIuUHJvdG9iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.CellInfoReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.ChessRogueCellInfo), global::EggLink.DanhengServer.Proto.ChessRogueCellInfo.Parser, new[]{ "IEHKBCMFBFB", "JJMALKDEFGE", "CellList", "DHFBLEOOILD", "CurId" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class ChessRogueCellInfo : pb::IMessage<ChessRogueCellInfo>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ChessRogueCellInfo> _parser = new pb::MessageParser<ChessRogueCellInfo>(() => new ChessRogueCellInfo());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ChessRogueCellInfo> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.ChessRogueCellInfoReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueCellInfo() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueCellInfo(ChessRogueCellInfo other) : this() {
      iEHKBCMFBFB_ = other.iEHKBCMFBFB_;
      jJMALKDEFGE_ = other.jJMALKDEFGE_;
      cellList_ = other.cellList_.Clone();
      dHFBLEOOILD_ = other.dHFBLEOOILD_;
      curId_ = other.curId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueCellInfo Clone() {
      return new ChessRogueCellInfo(this);
    }

    /// <summary>Field number for the "IEHKBCMFBFB" field.</summary>
    public const int IEHKBCMFBFBFieldNumber = 5;
    private uint iEHKBCMFBFB_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint IEHKBCMFBFB {
      get { return iEHKBCMFBFB_; }
      set {
        iEHKBCMFBFB_ = value;
      }
    }

    /// <summary>Field number for the "JJMALKDEFGE" field.</summary>
    public const int JJMALKDEFGEFieldNumber = 9;
    private uint jJMALKDEFGE_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint JJMALKDEFGE {
      get { return jJMALKDEFGE_; }
      set {
        jJMALKDEFGE_ = value;
      }
    }

    /// <summary>Field number for the "cell_list" field.</summary>
    public const int CellListFieldNumber = 6;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.CellInfo> _repeated_cellList_codec
        = pb::FieldCodec.ForMessage(50, global::EggLink.DanhengServer.Proto.CellInfo.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.CellInfo> cellList_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.CellInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.CellInfo> CellList {
      get { return cellList_; }
    }

    /// <summary>Field number for the "DHFBLEOOILD" field.</summary>
    public const int DHFBLEOOILDFieldNumber = 1;
    private uint dHFBLEOOILD_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint DHFBLEOOILD {
      get { return dHFBLEOOILD_; }
      set {
        dHFBLEOOILD_ = value;
      }
    }

    /// <summary>Field number for the "cur_id" field.</summary>
    public const int CurIdFieldNumber = 7;
    private uint curId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint CurId {
      get { return curId_; }
      set {
        curId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ChessRogueCellInfo);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ChessRogueCellInfo other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (IEHKBCMFBFB != other.IEHKBCMFBFB) return false;
      if (JJMALKDEFGE != other.JJMALKDEFGE) return false;
      if(!cellList_.Equals(other.cellList_)) return false;
      if (DHFBLEOOILD != other.DHFBLEOOILD) return false;
      if (CurId != other.CurId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (IEHKBCMFBFB != 0) hash ^= IEHKBCMFBFB.GetHashCode();
      if (JJMALKDEFGE != 0) hash ^= JJMALKDEFGE.GetHashCode();
      hash ^= cellList_.GetHashCode();
      if (DHFBLEOOILD != 0) hash ^= DHFBLEOOILD.GetHashCode();
      if (CurId != 0) hash ^= CurId.GetHashCode();
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
      if (DHFBLEOOILD != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(DHFBLEOOILD);
      }
      if (IEHKBCMFBFB != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(IEHKBCMFBFB);
      }
      cellList_.WriteTo(output, _repeated_cellList_codec);
      if (CurId != 0) {
        output.WriteRawTag(56);
        output.WriteUInt32(CurId);
      }
      if (JJMALKDEFGE != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(JJMALKDEFGE);
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
      if (DHFBLEOOILD != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(DHFBLEOOILD);
      }
      if (IEHKBCMFBFB != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(IEHKBCMFBFB);
      }
      cellList_.WriteTo(ref output, _repeated_cellList_codec);
      if (CurId != 0) {
        output.WriteRawTag(56);
        output.WriteUInt32(CurId);
      }
      if (JJMALKDEFGE != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(JJMALKDEFGE);
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
      if (IEHKBCMFBFB != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(IEHKBCMFBFB);
      }
      if (JJMALKDEFGE != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(JJMALKDEFGE);
      }
      size += cellList_.CalculateSize(_repeated_cellList_codec);
      if (DHFBLEOOILD != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(DHFBLEOOILD);
      }
      if (CurId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CurId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ChessRogueCellInfo other) {
      if (other == null) {
        return;
      }
      if (other.IEHKBCMFBFB != 0) {
        IEHKBCMFBFB = other.IEHKBCMFBFB;
      }
      if (other.JJMALKDEFGE != 0) {
        JJMALKDEFGE = other.JJMALKDEFGE;
      }
      cellList_.Add(other.cellList_);
      if (other.DHFBLEOOILD != 0) {
        DHFBLEOOILD = other.DHFBLEOOILD;
      }
      if (other.CurId != 0) {
        CurId = other.CurId;
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
          case 8: {
            DHFBLEOOILD = input.ReadUInt32();
            break;
          }
          case 40: {
            IEHKBCMFBFB = input.ReadUInt32();
            break;
          }
          case 50: {
            cellList_.AddEntriesFrom(input, _repeated_cellList_codec);
            break;
          }
          case 56: {
            CurId = input.ReadUInt32();
            break;
          }
          case 72: {
            JJMALKDEFGE = input.ReadUInt32();
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
          case 8: {
            DHFBLEOOILD = input.ReadUInt32();
            break;
          }
          case 40: {
            IEHKBCMFBFB = input.ReadUInt32();
            break;
          }
          case 50: {
            cellList_.AddEntriesFrom(ref input, _repeated_cellList_codec);
            break;
          }
          case 56: {
            CurId = input.ReadUInt32();
            break;
          }
          case 72: {
            JJMALKDEFGE = input.ReadUInt32();
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