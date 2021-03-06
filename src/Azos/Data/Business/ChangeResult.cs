﻿/*<FILE_LICENSE>
 * Azos (A to Z Application Operating System) Framework
 * The A to Z Foundation (a.k.a. Azist) licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
</FILE_LICENSE>*/

using System.Collections;
using System.IO;

using Azos.Serialization.JSON;

namespace Azos.Data.Business
{
  /// <summary>
  /// Describes data change operation result: {ChangeType, AffectedCount, Message, Data}
  /// </summary>
  public struct ChangeResult : IJsonWritable
  {
    /// <summary>
    /// Change types: Inserted/Updated/Upserted/Deleted
    /// </summary>
    public enum ChangeType
    {
      Undefined = 0,
      Inserted,
      Updated,
      Upserted,
      Deleted
    }

    /// <summary>
    /// Describes data change operation result: Inserted/Deleted/etc.., rows affected, extra data etc.
    /// </summary>
    /// <param name="change">Change type: Inserted/Updated...</param>
    /// <param name="affectedCount">Affected entity count</param>
    /// <param name="msg">Optional message from the serving party</param>
    /// <param name="data">Returns optional extra data which is returned from the data change operation</param>
    public ChangeResult(ChangeType change, long affectedCount, string msg, object data)
    {
      Change = change;
      AffectedCount = affectedCount;
      Message = msg;
      Data = data;
    }

    /// <summary> Specifies the change type Insert/Update/Delete etc.. </summary>
    public readonly ChangeType Change;

    /// <summary> How many entities/rows/docs was/were affected by the change </summary>
    public readonly long AffectedCount;

    /// <summary> Provides an optional message from the serving party </summary>
    public readonly string Message;

    /// <summary>
    /// Attaches optional extra data which is returned from the data change operation,
    /// for example a posted sale may return an OrderId object generated by the target store
    /// </summary>
    public readonly object Data;

    /// <summary>
    /// Writes this ChangeResult as a typical JSON object like: {OK: true, change: Inserted ... }
    /// </summary>
    void IJsonWritable.WriteAsJson(TextWriter wri, int nestingLevel, JsonWritingOptions options)
    {
      JsonWriter.WriteMap(wri, nestingLevel, options,
                    new DictionaryEntry("OK", true),
                    new DictionaryEntry("change", Change),
                    new DictionaryEntry("affected", AffectedCount),
                    new DictionaryEntry("message", Message),
                    new DictionaryEntry("data", Data)
                   );
    }

  }
}
