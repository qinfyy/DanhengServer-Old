// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CurChallenge.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from CurChallenge.proto</summary>
  public static partial class CurChallengeReflection {

    #region Descriptor
    /// <summary>File descriptor for CurChallenge.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CurChallengeReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJDdXJDaGFsbGVuZ2UucHJvdG8aFUV4dHJhTGluZXVwVHlwZS5wcm90bxoV",
            "Q2hhbGxlbmdlU3RhdHVzLnByb3RvGhVLaWxsTW9uc3RlckluZm8ucHJvdG8a",
            "EUdOQUZOTVBJSUNDLnByb3RvIpICCgxDdXJDaGFsbGVuZ2USKwoRZXh0cmFf",
            "bGluZXVwX3R5cGUYBCABKA4yEC5FeHRyYUxpbmV1cFR5cGUSEwoLSUZHSUtN",
            "SElOSEsYAiABKA0SHwoJY2VsbF9pbmZvGAYgASgLMgwuR05BRk5NUElJQ0MS",
            "IAoGc3RhdHVzGAogASgOMhAuQ2hhbGxlbmdlU3RhdHVzEisKEWtpbGxfbW9u",
            "c3Rlcl9saXN0GAEgAygLMhAuS2lsbE1vbnN0ZXJJbmZvEhMKC0VQSUJIR0dE",
            "TEhDGAwgASgNEhMKC0ZJT09JRU1DQ0dNGAUgASgNEhAKCHNjb3JlX2lkGAkg",
            "ASgNEhQKDGNoYWxsZW5nZV9pZBgOIAEoDUIeqgIbRWdnTGluay5EYW5oZW5n",
            "U2VydmVyLlByb3RvYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.ExtraLineupTypeReflection.Descriptor, global::EggLink.DanhengServer.Proto.ChallengeStatusReflection.Descriptor, global::EggLink.DanhengServer.Proto.KillMonsterInfoReflection.Descriptor, global::EggLink.DanhengServer.Proto.GNAFNMPIICCReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.CurChallenge), global::EggLink.DanhengServer.Proto.CurChallenge.Parser, new[]{ "ExtraLineupType", "IFGIKMHINHK", "CellInfo", "Status", "KillMonsterList", "EPIBHGGDLHC", "FIOOIEMCCGM", "ScoreId", "ChallengeId" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class CurChallenge : pb::IMessage<CurChallenge>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<CurChallenge> _parser = new pb::MessageParser<CurChallenge>(() => new CurChallenge());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<CurChallenge> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.CurChallengeReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CurChallenge() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CurChallenge(CurChallenge other) : this() {
      extraLineupType_ = other.extraLineupType_;
      iFGIKMHINHK_ = other.iFGIKMHINHK_;
      cellInfo_ = other.cellInfo_ != null ? other.cellInfo_.Clone() : null;
      status_ = other.status_;
      killMonsterList_ = other.killMonsterList_.Clone();
      ePIBHGGDLHC_ = other.ePIBHGGDLHC_;
      fIOOIEMCCGM_ = other.fIOOIEMCCGM_;
      scoreId_ = other.scoreId_;
      challengeId_ = other.challengeId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public CurChallenge Clone() {
      return new CurChallenge(this);
    }

    /// <summary>Field number for the "extra_lineup_type" field.</summary>
    public const int ExtraLineupTypeFieldNumber = 4;
    private global::EggLink.DanhengServer.Proto.ExtraLineupType extraLineupType_ = global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.ExtraLineupType ExtraLineupType {
      get { return extraLineupType_; }
      set {
        extraLineupType_ = value;
      }
    }

    /// <summary>Field number for the "IFGIKMHINHK" field.</summary>
    public const int IFGIKMHINHKFieldNumber = 2;
    private uint iFGIKMHINHK_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint IFGIKMHINHK {
      get { return iFGIKMHINHK_; }
      set {
        iFGIKMHINHK_ = value;
      }
    }

    /// <summary>Field number for the "cell_info" field.</summary>
    public const int CellInfoFieldNumber = 6;
    private global::EggLink.DanhengServer.Proto.GNAFNMPIICC cellInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.GNAFNMPIICC CellInfo {
      get { return cellInfo_; }
      set {
        cellInfo_ = value;
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 10;
    private global::EggLink.DanhengServer.Proto.ChallengeStatus status_ = global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.ChallengeStatus Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "kill_monster_list" field.</summary>
    public const int KillMonsterListFieldNumber = 1;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.KillMonsterInfo> _repeated_killMonsterList_codec
        = pb::FieldCodec.ForMessage(10, global::EggLink.DanhengServer.Proto.KillMonsterInfo.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.KillMonsterInfo> killMonsterList_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.KillMonsterInfo>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.KillMonsterInfo> KillMonsterList {
      get { return killMonsterList_; }
    }

    /// <summary>Field number for the "EPIBHGGDLHC" field.</summary>
    public const int EPIBHGGDLHCFieldNumber = 12;
    private uint ePIBHGGDLHC_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint EPIBHGGDLHC {
      get { return ePIBHGGDLHC_; }
      set {
        ePIBHGGDLHC_ = value;
      }
    }

    /// <summary>Field number for the "FIOOIEMCCGM" field.</summary>
    public const int FIOOIEMCCGMFieldNumber = 5;
    private uint fIOOIEMCCGM_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint FIOOIEMCCGM {
      get { return fIOOIEMCCGM_; }
      set {
        fIOOIEMCCGM_ = value;
      }
    }

    /// <summary>Field number for the "score_id" field.</summary>
    public const int ScoreIdFieldNumber = 9;
    private uint scoreId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ScoreId {
      get { return scoreId_; }
      set {
        scoreId_ = value;
      }
    }

    /// <summary>Field number for the "challenge_id" field.</summary>
    public const int ChallengeIdFieldNumber = 14;
    private uint challengeId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint ChallengeId {
      get { return challengeId_; }
      set {
        challengeId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as CurChallenge);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(CurChallenge other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ExtraLineupType != other.ExtraLineupType) return false;
      if (IFGIKMHINHK != other.IFGIKMHINHK) return false;
      if (!object.Equals(CellInfo, other.CellInfo)) return false;
      if (Status != other.Status) return false;
      if(!killMonsterList_.Equals(other.killMonsterList_)) return false;
      if (EPIBHGGDLHC != other.EPIBHGGDLHC) return false;
      if (FIOOIEMCCGM != other.FIOOIEMCCGM) return false;
      if (ScoreId != other.ScoreId) return false;
      if (ChallengeId != other.ChallengeId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ExtraLineupType != global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone) hash ^= ExtraLineupType.GetHashCode();
      if (IFGIKMHINHK != 0) hash ^= IFGIKMHINHK.GetHashCode();
      if (cellInfo_ != null) hash ^= CellInfo.GetHashCode();
      if (Status != global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown) hash ^= Status.GetHashCode();
      hash ^= killMonsterList_.GetHashCode();
      if (EPIBHGGDLHC != 0) hash ^= EPIBHGGDLHC.GetHashCode();
      if (FIOOIEMCCGM != 0) hash ^= FIOOIEMCCGM.GetHashCode();
      if (ScoreId != 0) hash ^= ScoreId.GetHashCode();
      if (ChallengeId != 0) hash ^= ChallengeId.GetHashCode();
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
      killMonsterList_.WriteTo(output, _repeated_killMonsterList_codec);
      if (IFGIKMHINHK != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(IFGIKMHINHK);
      }
      if (ExtraLineupType != global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone) {
        output.WriteRawTag(32);
        output.WriteEnum((int) ExtraLineupType);
      }
      if (FIOOIEMCCGM != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(FIOOIEMCCGM);
      }
      if (cellInfo_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(CellInfo);
      }
      if (ScoreId != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(ScoreId);
      }
      if (Status != global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown) {
        output.WriteRawTag(80);
        output.WriteEnum((int) Status);
      }
      if (EPIBHGGDLHC != 0) {
        output.WriteRawTag(96);
        output.WriteUInt32(EPIBHGGDLHC);
      }
      if (ChallengeId != 0) {
        output.WriteRawTag(112);
        output.WriteUInt32(ChallengeId);
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
      killMonsterList_.WriteTo(ref output, _repeated_killMonsterList_codec);
      if (IFGIKMHINHK != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(IFGIKMHINHK);
      }
      if (ExtraLineupType != global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone) {
        output.WriteRawTag(32);
        output.WriteEnum((int) ExtraLineupType);
      }
      if (FIOOIEMCCGM != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(FIOOIEMCCGM);
      }
      if (cellInfo_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(CellInfo);
      }
      if (ScoreId != 0) {
        output.WriteRawTag(72);
        output.WriteUInt32(ScoreId);
      }
      if (Status != global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown) {
        output.WriteRawTag(80);
        output.WriteEnum((int) Status);
      }
      if (EPIBHGGDLHC != 0) {
        output.WriteRawTag(96);
        output.WriteUInt32(EPIBHGGDLHC);
      }
      if (ChallengeId != 0) {
        output.WriteRawTag(112);
        output.WriteUInt32(ChallengeId);
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
      if (ExtraLineupType != global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) ExtraLineupType);
      }
      if (IFGIKMHINHK != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(IFGIKMHINHK);
      }
      if (cellInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CellInfo);
      }
      if (Status != global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      size += killMonsterList_.CalculateSize(_repeated_killMonsterList_codec);
      if (EPIBHGGDLHC != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(EPIBHGGDLHC);
      }
      if (FIOOIEMCCGM != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(FIOOIEMCCGM);
      }
      if (ScoreId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ScoreId);
      }
      if (ChallengeId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(ChallengeId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(CurChallenge other) {
      if (other == null) {
        return;
      }
      if (other.ExtraLineupType != global::EggLink.DanhengServer.Proto.ExtraLineupType.LineupNone) {
        ExtraLineupType = other.ExtraLineupType;
      }
      if (other.IFGIKMHINHK != 0) {
        IFGIKMHINHK = other.IFGIKMHINHK;
      }
      if (other.cellInfo_ != null) {
        if (cellInfo_ == null) {
          CellInfo = new global::EggLink.DanhengServer.Proto.GNAFNMPIICC();
        }
        CellInfo.MergeFrom(other.CellInfo);
      }
      if (other.Status != global::EggLink.DanhengServer.Proto.ChallengeStatus.ChallengeUnknown) {
        Status = other.Status;
      }
      killMonsterList_.Add(other.killMonsterList_);
      if (other.EPIBHGGDLHC != 0) {
        EPIBHGGDLHC = other.EPIBHGGDLHC;
      }
      if (other.FIOOIEMCCGM != 0) {
        FIOOIEMCCGM = other.FIOOIEMCCGM;
      }
      if (other.ScoreId != 0) {
        ScoreId = other.ScoreId;
      }
      if (other.ChallengeId != 0) {
        ChallengeId = other.ChallengeId;
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
            killMonsterList_.AddEntriesFrom(input, _repeated_killMonsterList_codec);
            break;
          }
          case 16: {
            IFGIKMHINHK = input.ReadUInt32();
            break;
          }
          case 32: {
            ExtraLineupType = (global::EggLink.DanhengServer.Proto.ExtraLineupType) input.ReadEnum();
            break;
          }
          case 40: {
            FIOOIEMCCGM = input.ReadUInt32();
            break;
          }
          case 50: {
            if (cellInfo_ == null) {
              CellInfo = new global::EggLink.DanhengServer.Proto.GNAFNMPIICC();
            }
            input.ReadMessage(CellInfo);
            break;
          }
          case 72: {
            ScoreId = input.ReadUInt32();
            break;
          }
          case 80: {
            Status = (global::EggLink.DanhengServer.Proto.ChallengeStatus) input.ReadEnum();
            break;
          }
          case 96: {
            EPIBHGGDLHC = input.ReadUInt32();
            break;
          }
          case 112: {
            ChallengeId = input.ReadUInt32();
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
            killMonsterList_.AddEntriesFrom(ref input, _repeated_killMonsterList_codec);
            break;
          }
          case 16: {
            IFGIKMHINHK = input.ReadUInt32();
            break;
          }
          case 32: {
            ExtraLineupType = (global::EggLink.DanhengServer.Proto.ExtraLineupType) input.ReadEnum();
            break;
          }
          case 40: {
            FIOOIEMCCGM = input.ReadUInt32();
            break;
          }
          case 50: {
            if (cellInfo_ == null) {
              CellInfo = new global::EggLink.DanhengServer.Proto.GNAFNMPIICC();
            }
            input.ReadMessage(CellInfo);
            break;
          }
          case 72: {
            ScoreId = input.ReadUInt32();
            break;
          }
          case 80: {
            Status = (global::EggLink.DanhengServer.Proto.ChallengeStatus) input.ReadEnum();
            break;
          }
          case 96: {
            EPIBHGGDLHC = input.ReadUInt32();
            break;
          }
          case 112: {
            ChallengeId = input.ReadUInt32();
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