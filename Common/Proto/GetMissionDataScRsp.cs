// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: GetMissionDataScRsp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from GetMissionDataScRsp.proto</summary>
  public static partial class GetMissionDataScRspReflection {

    #region Descriptor
    /// <summary>File descriptor for GetMissionDataScRsp.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static GetMissionDataScRspReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlHZXRNaXNzaW9uRGF0YVNjUnNwLnByb3RvGg1NaXNzaW9uLnByb3RvGhFN",
            "aXNzaW9uRGF0YS5wcm90byKEAQoTR2V0TWlzc2lvbkRhdGFTY1JzcBIeCgxt",
            "aXNzaW9uX2xpc3QYBCADKAsyCC5NaXNzaW9uEg8KB3JldGNvZGUYCyABKA0S",
            "EwoLTEZPR0ZKTURNQ0cYBiABKA0SJwoRbWlzc2lvbl9kYXRhX2xpc3QYAyAD",
            "KAsyDC5NaXNzaW9uRGF0YUIeqgIbRWdnTGluay5EYW5oZW5nU2VydmVyLlBy",
            "b3RvYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.MissionReflection.Descriptor, global::EggLink.DanhengServer.Proto.MissionDataReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.GetMissionDataScRsp), global::EggLink.DanhengServer.Proto.GetMissionDataScRsp.Parser, new[]{ "MissionList", "Retcode", "LFOGFJMDMCG", "MissionDataList" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class GetMissionDataScRsp : pb::IMessage<GetMissionDataScRsp>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetMissionDataScRsp> _parser = new pb::MessageParser<GetMissionDataScRsp>(() => new GetMissionDataScRsp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetMissionDataScRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.GetMissionDataScRspReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetMissionDataScRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetMissionDataScRsp(GetMissionDataScRsp other) : this() {
      missionList_ = other.missionList_.Clone();
      retcode_ = other.retcode_;
      lFOGFJMDMCG_ = other.lFOGFJMDMCG_;
      missionDataList_ = other.missionDataList_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetMissionDataScRsp Clone() {
      return new GetMissionDataScRsp(this);
    }

    /// <summary>Field number for the "mission_list" field.</summary>
    public const int MissionListFieldNumber = 4;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.Mission> _repeated_missionList_codec
        = pb::FieldCodec.ForMessage(34, global::EggLink.DanhengServer.Proto.Mission.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.Mission> missionList_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.Mission>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.Mission> MissionList {
      get { return missionList_; }
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

    /// <summary>Field number for the "LFOGFJMDMCG" field.</summary>
    public const int LFOGFJMDMCGFieldNumber = 6;
    private uint lFOGFJMDMCG_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint LFOGFJMDMCG {
      get { return lFOGFJMDMCG_; }
      set {
        lFOGFJMDMCG_ = value;
      }
    }

    /// <summary>Field number for the "mission_data_list" field.</summary>
    public const int MissionDataListFieldNumber = 3;
    private static readonly pb::FieldCodec<global::EggLink.DanhengServer.Proto.MissionData> _repeated_missionDataList_codec
        = pb::FieldCodec.ForMessage(26, global::EggLink.DanhengServer.Proto.MissionData.Parser);
    private readonly pbc::RepeatedField<global::EggLink.DanhengServer.Proto.MissionData> missionDataList_ = new pbc::RepeatedField<global::EggLink.DanhengServer.Proto.MissionData>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::EggLink.DanhengServer.Proto.MissionData> MissionDataList {
      get { return missionDataList_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetMissionDataScRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetMissionDataScRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!missionList_.Equals(other.missionList_)) return false;
      if (Retcode != other.Retcode) return false;
      if (LFOGFJMDMCG != other.LFOGFJMDMCG) return false;
      if(!missionDataList_.Equals(other.missionDataList_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= missionList_.GetHashCode();
      if (Retcode != 0) hash ^= Retcode.GetHashCode();
      if (LFOGFJMDMCG != 0) hash ^= LFOGFJMDMCG.GetHashCode();
      hash ^= missionDataList_.GetHashCode();
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
      missionDataList_.WriteTo(output, _repeated_missionDataList_codec);
      missionList_.WriteTo(output, _repeated_missionList_codec);
      if (LFOGFJMDMCG != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(LFOGFJMDMCG);
      }
      if (Retcode != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(Retcode);
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
      missionDataList_.WriteTo(ref output, _repeated_missionDataList_codec);
      missionList_.WriteTo(ref output, _repeated_missionList_codec);
      if (LFOGFJMDMCG != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(LFOGFJMDMCG);
      }
      if (Retcode != 0) {
        output.WriteRawTag(88);
        output.WriteUInt32(Retcode);
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
      size += missionList_.CalculateSize(_repeated_missionList_codec);
      if (Retcode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Retcode);
      }
      if (LFOGFJMDMCG != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(LFOGFJMDMCG);
      }
      size += missionDataList_.CalculateSize(_repeated_missionDataList_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetMissionDataScRsp other) {
      if (other == null) {
        return;
      }
      missionList_.Add(other.missionList_);
      if (other.Retcode != 0) {
        Retcode = other.Retcode;
      }
      if (other.LFOGFJMDMCG != 0) {
        LFOGFJMDMCG = other.LFOGFJMDMCG;
      }
      missionDataList_.Add(other.missionDataList_);
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
          case 26: {
            missionDataList_.AddEntriesFrom(input, _repeated_missionDataList_codec);
            break;
          }
          case 34: {
            missionList_.AddEntriesFrom(input, _repeated_missionList_codec);
            break;
          }
          case 48: {
            LFOGFJMDMCG = input.ReadUInt32();
            break;
          }
          case 88: {
            Retcode = input.ReadUInt32();
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
          case 26: {
            missionDataList_.AddEntriesFrom(ref input, _repeated_missionDataList_codec);
            break;
          }
          case 34: {
            missionList_.AddEntriesFrom(ref input, _repeated_missionList_codec);
            break;
          }
          case 48: {
            LFOGFJMDMCG = input.ReadUInt32();
            break;
          }
          case 88: {
            Retcode = input.ReadUInt32();
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