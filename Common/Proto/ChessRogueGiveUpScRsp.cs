// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ChessRogueGiveUpScRsp.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace EggLink.DanhengServer.Proto {

  /// <summary>Holder for reflection information generated from ChessRogueGiveUpScRsp.proto</summary>
  public static partial class ChessRogueGiveUpScRspReflection {

    #region Descriptor
    /// <summary>File descriptor for ChessRogueGiveUpScRsp.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ChessRogueGiveUpScRspReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChtDaGVzc1JvZ3VlR2l2ZVVwU2NSc3AucHJvdG8aEUtPR0pKTUJFRERFLnBy",
            "b3RvGhFKUERIT05QSUNJRC5wcm90bxoRQVBDS09CS0RHRkcucHJvdG8aEUlH",
            "REtPTE5BRktQLnByb3RvGhFDTkhHSkRMQUVITC5wcm90byLeAQoVQ2hlc3NS",
            "b2d1ZUdpdmVVcFNjUnNwEiUKD3JvZ3VlX2Flb25faW5mbxgMIAEoCzIMLkFQ",
            "Q0tPQktER0ZHEg8KB3JldGNvZGUYDiABKA0SJAoOcm9ndWVfZ2V0X2luZm8Y",
            "CyABKAsyDC5JR0RLT0xOQUZLUBIhCgtDR0VCS09GQktKTxgJIAEoCzIMLktP",
            "R0pKTUJFRERFEiEKC0FOTk5CSEpETVBNGAggASgLMgwuSlBESE9OUElDSUQS",
            "IQoLUEJIT0pOTEtLT0wYASABKAsyDC5DTkhHSkRMQUVITEIeqgIbRWdnTGlu",
            "ay5EYW5oZW5nU2VydmVyLlByb3RvYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::EggLink.DanhengServer.Proto.KOGJJMBEDDEReflection.Descriptor, global::EggLink.DanhengServer.Proto.JPDHONPICIDReflection.Descriptor, global::EggLink.DanhengServer.Proto.APCKOBKDGFGReflection.Descriptor, global::EggLink.DanhengServer.Proto.IGDKOLNAFKPReflection.Descriptor, global::EggLink.DanhengServer.Proto.CNHGJDLAEHLReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::EggLink.DanhengServer.Proto.ChessRogueGiveUpScRsp), global::EggLink.DanhengServer.Proto.ChessRogueGiveUpScRsp.Parser, new[]{ "RogueAeonInfo", "Retcode", "RogueGetInfo", "CGEBKOFBKJO", "ANNNBHJDMPM", "PBHOJNLKKOL" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class ChessRogueGiveUpScRsp : pb::IMessage<ChessRogueGiveUpScRsp>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ChessRogueGiveUpScRsp> _parser = new pb::MessageParser<ChessRogueGiveUpScRsp>(() => new ChessRogueGiveUpScRsp());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ChessRogueGiveUpScRsp> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::EggLink.DanhengServer.Proto.ChessRogueGiveUpScRspReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueGiveUpScRsp() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueGiveUpScRsp(ChessRogueGiveUpScRsp other) : this() {
      rogueAeonInfo_ = other.rogueAeonInfo_ != null ? other.rogueAeonInfo_.Clone() : null;
      retcode_ = other.retcode_;
      rogueGetInfo_ = other.rogueGetInfo_ != null ? other.rogueGetInfo_.Clone() : null;
      cGEBKOFBKJO_ = other.cGEBKOFBKJO_ != null ? other.cGEBKOFBKJO_.Clone() : null;
      aNNNBHJDMPM_ = other.aNNNBHJDMPM_ != null ? other.aNNNBHJDMPM_.Clone() : null;
      pBHOJNLKKOL_ = other.pBHOJNLKKOL_ != null ? other.pBHOJNLKKOL_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ChessRogueGiveUpScRsp Clone() {
      return new ChessRogueGiveUpScRsp(this);
    }

    /// <summary>Field number for the "rogue_aeon_info" field.</summary>
    public const int RogueAeonInfoFieldNumber = 12;
    private global::EggLink.DanhengServer.Proto.APCKOBKDGFG rogueAeonInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.APCKOBKDGFG RogueAeonInfo {
      get { return rogueAeonInfo_; }
      set {
        rogueAeonInfo_ = value;
      }
    }

    /// <summary>Field number for the "retcode" field.</summary>
    public const int RetcodeFieldNumber = 14;
    private uint retcode_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public uint Retcode {
      get { return retcode_; }
      set {
        retcode_ = value;
      }
    }

    /// <summary>Field number for the "rogue_get_info" field.</summary>
    public const int RogueGetInfoFieldNumber = 11;
    private global::EggLink.DanhengServer.Proto.IGDKOLNAFKP rogueGetInfo_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.IGDKOLNAFKP RogueGetInfo {
      get { return rogueGetInfo_; }
      set {
        rogueGetInfo_ = value;
      }
    }

    /// <summary>Field number for the "CGEBKOFBKJO" field.</summary>
    public const int CGEBKOFBKJOFieldNumber = 9;
    private global::EggLink.DanhengServer.Proto.KOGJJMBEDDE cGEBKOFBKJO_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.KOGJJMBEDDE CGEBKOFBKJO {
      get { return cGEBKOFBKJO_; }
      set {
        cGEBKOFBKJO_ = value;
      }
    }

    /// <summary>Field number for the "ANNNBHJDMPM" field.</summary>
    public const int ANNNBHJDMPMFieldNumber = 8;
    private global::EggLink.DanhengServer.Proto.JPDHONPICID aNNNBHJDMPM_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.JPDHONPICID ANNNBHJDMPM {
      get { return aNNNBHJDMPM_; }
      set {
        aNNNBHJDMPM_ = value;
      }
    }

    /// <summary>Field number for the "PBHOJNLKKOL" field.</summary>
    public const int PBHOJNLKKOLFieldNumber = 1;
    private global::EggLink.DanhengServer.Proto.CNHGJDLAEHL pBHOJNLKKOL_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::EggLink.DanhengServer.Proto.CNHGJDLAEHL PBHOJNLKKOL {
      get { return pBHOJNLKKOL_; }
      set {
        pBHOJNLKKOL_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ChessRogueGiveUpScRsp);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ChessRogueGiveUpScRsp other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(RogueAeonInfo, other.RogueAeonInfo)) return false;
      if (Retcode != other.Retcode) return false;
      if (!object.Equals(RogueGetInfo, other.RogueGetInfo)) return false;
      if (!object.Equals(CGEBKOFBKJO, other.CGEBKOFBKJO)) return false;
      if (!object.Equals(ANNNBHJDMPM, other.ANNNBHJDMPM)) return false;
      if (!object.Equals(PBHOJNLKKOL, other.PBHOJNLKKOL)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (rogueAeonInfo_ != null) hash ^= RogueAeonInfo.GetHashCode();
      if (Retcode != 0) hash ^= Retcode.GetHashCode();
      if (rogueGetInfo_ != null) hash ^= RogueGetInfo.GetHashCode();
      if (cGEBKOFBKJO_ != null) hash ^= CGEBKOFBKJO.GetHashCode();
      if (aNNNBHJDMPM_ != null) hash ^= ANNNBHJDMPM.GetHashCode();
      if (pBHOJNLKKOL_ != null) hash ^= PBHOJNLKKOL.GetHashCode();
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
      if (pBHOJNLKKOL_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(PBHOJNLKKOL);
      }
      if (aNNNBHJDMPM_ != null) {
        output.WriteRawTag(66);
        output.WriteMessage(ANNNBHJDMPM);
      }
      if (cGEBKOFBKJO_ != null) {
        output.WriteRawTag(74);
        output.WriteMessage(CGEBKOFBKJO);
      }
      if (rogueGetInfo_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(RogueGetInfo);
      }
      if (rogueAeonInfo_ != null) {
        output.WriteRawTag(98);
        output.WriteMessage(RogueAeonInfo);
      }
      if (Retcode != 0) {
        output.WriteRawTag(112);
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
      if (pBHOJNLKKOL_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(PBHOJNLKKOL);
      }
      if (aNNNBHJDMPM_ != null) {
        output.WriteRawTag(66);
        output.WriteMessage(ANNNBHJDMPM);
      }
      if (cGEBKOFBKJO_ != null) {
        output.WriteRawTag(74);
        output.WriteMessage(CGEBKOFBKJO);
      }
      if (rogueGetInfo_ != null) {
        output.WriteRawTag(90);
        output.WriteMessage(RogueGetInfo);
      }
      if (rogueAeonInfo_ != null) {
        output.WriteRawTag(98);
        output.WriteMessage(RogueAeonInfo);
      }
      if (Retcode != 0) {
        output.WriteRawTag(112);
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
      if (rogueAeonInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RogueAeonInfo);
      }
      if (Retcode != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Retcode);
      }
      if (rogueGetInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RogueGetInfo);
      }
      if (cGEBKOFBKJO_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CGEBKOFBKJO);
      }
      if (aNNNBHJDMPM_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ANNNBHJDMPM);
      }
      if (pBHOJNLKKOL_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PBHOJNLKKOL);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ChessRogueGiveUpScRsp other) {
      if (other == null) {
        return;
      }
      if (other.rogueAeonInfo_ != null) {
        if (rogueAeonInfo_ == null) {
          RogueAeonInfo = new global::EggLink.DanhengServer.Proto.APCKOBKDGFG();
        }
        RogueAeonInfo.MergeFrom(other.RogueAeonInfo);
      }
      if (other.Retcode != 0) {
        Retcode = other.Retcode;
      }
      if (other.rogueGetInfo_ != null) {
        if (rogueGetInfo_ == null) {
          RogueGetInfo = new global::EggLink.DanhengServer.Proto.IGDKOLNAFKP();
        }
        RogueGetInfo.MergeFrom(other.RogueGetInfo);
      }
      if (other.cGEBKOFBKJO_ != null) {
        if (cGEBKOFBKJO_ == null) {
          CGEBKOFBKJO = new global::EggLink.DanhengServer.Proto.KOGJJMBEDDE();
        }
        CGEBKOFBKJO.MergeFrom(other.CGEBKOFBKJO);
      }
      if (other.aNNNBHJDMPM_ != null) {
        if (aNNNBHJDMPM_ == null) {
          ANNNBHJDMPM = new global::EggLink.DanhengServer.Proto.JPDHONPICID();
        }
        ANNNBHJDMPM.MergeFrom(other.ANNNBHJDMPM);
      }
      if (other.pBHOJNLKKOL_ != null) {
        if (pBHOJNLKKOL_ == null) {
          PBHOJNLKKOL = new global::EggLink.DanhengServer.Proto.CNHGJDLAEHL();
        }
        PBHOJNLKKOL.MergeFrom(other.PBHOJNLKKOL);
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
            if (pBHOJNLKKOL_ == null) {
              PBHOJNLKKOL = new global::EggLink.DanhengServer.Proto.CNHGJDLAEHL();
            }
            input.ReadMessage(PBHOJNLKKOL);
            break;
          }
          case 66: {
            if (aNNNBHJDMPM_ == null) {
              ANNNBHJDMPM = new global::EggLink.DanhengServer.Proto.JPDHONPICID();
            }
            input.ReadMessage(ANNNBHJDMPM);
            break;
          }
          case 74: {
            if (cGEBKOFBKJO_ == null) {
              CGEBKOFBKJO = new global::EggLink.DanhengServer.Proto.KOGJJMBEDDE();
            }
            input.ReadMessage(CGEBKOFBKJO);
            break;
          }
          case 90: {
            if (rogueGetInfo_ == null) {
              RogueGetInfo = new global::EggLink.DanhengServer.Proto.IGDKOLNAFKP();
            }
            input.ReadMessage(RogueGetInfo);
            break;
          }
          case 98: {
            if (rogueAeonInfo_ == null) {
              RogueAeonInfo = new global::EggLink.DanhengServer.Proto.APCKOBKDGFG();
            }
            input.ReadMessage(RogueAeonInfo);
            break;
          }
          case 112: {
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
          case 10: {
            if (pBHOJNLKKOL_ == null) {
              PBHOJNLKKOL = new global::EggLink.DanhengServer.Proto.CNHGJDLAEHL();
            }
            input.ReadMessage(PBHOJNLKKOL);
            break;
          }
          case 66: {
            if (aNNNBHJDMPM_ == null) {
              ANNNBHJDMPM = new global::EggLink.DanhengServer.Proto.JPDHONPICID();
            }
            input.ReadMessage(ANNNBHJDMPM);
            break;
          }
          case 74: {
            if (cGEBKOFBKJO_ == null) {
              CGEBKOFBKJO = new global::EggLink.DanhengServer.Proto.KOGJJMBEDDE();
            }
            input.ReadMessage(CGEBKOFBKJO);
            break;
          }
          case 90: {
            if (rogueGetInfo_ == null) {
              RogueGetInfo = new global::EggLink.DanhengServer.Proto.IGDKOLNAFKP();
            }
            input.ReadMessage(RogueGetInfo);
            break;
          }
          case 98: {
            if (rogueAeonInfo_ == null) {
              RogueAeonInfo = new global::EggLink.DanhengServer.Proto.APCKOBKDGFG();
            }
            input.ReadMessage(RogueAeonInfo);
            break;
          }
          case 112: {
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