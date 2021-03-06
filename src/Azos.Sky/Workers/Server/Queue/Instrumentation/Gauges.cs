/*<FILE_LICENSE>
 * Azos (A to Z Application Operating System) Framework
 * The A to Z Foundation (a.k.a. Azist) licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
</FILE_LICENSE>*/
using System;

using Azos.Instrumentation;
using Azos.Serialization.Arow;
using Azos.Serialization.BSON;

namespace Azos.Sky.Workers.Server.Queue.Instrumentation
{
  /// <summary>
  /// Provides base for TodoQueue long gauges
  /// </summary>
  [Serializable]
  public abstract class TodoQueueLongGauge : LongGauge, IQueueInstrument, IWorkerInstrument
  {
    protected TodoQueueLongGauge(string src, long value) : base(src, value) { }
  }

  /// <summary>
  /// How many times Enqueue(Todo[]) was called
  /// </summary>
  [Serializable]
  [Arow("8988006D-C320-40BB-AF76-49820DE329A4")]
  [BSONSerializable("8F0D962E-9944-416E-8B8B-9CDE6A729284")]
  public class EnqueueCalls : TodoQueueLongGauge
  {
    public EnqueueCalls(long value) : base(null, value) { }

    public override string Description { get { return "How many times Enqueue(Todo[]) was called"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_CALL; } }

    protected override Datum MakeAggregateInstance() { return new EnqueueCalls(0); }
  }

  /// <summary>
  /// How many Todo message instances got enqueued
  /// </summary>
  [Serializable]
  [Arow("528523EC-E17E-4EDD-ACD0-A72BC96CF3C1")]
  [BSONSerializable("54D5B7C2-E0F4-4236-9CE4-E5A0111526A3")]
  public class EnqueueTodoCount : TodoQueueLongGauge
  {
    public EnqueueTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo message instances got enqueued"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new EnqueueTodoCount(this.Source, 0); }
  }


  /// <summary>
  /// How many times the thread spun
  /// </summary>
  [Serializable]
  [Arow("28F0CB76-0B70-4085-BEC7-1383A59E21D5")]
  [BSONSerializable("A39A8D75-25DE-4047-AC62-E7D483A07DFE")]
  public class QueueThreadSpins : TodoQueueLongGauge
  {
    public QueueThreadSpins(long value) : base(null, value) { }

    public override string Description { get { return "How many times the thread spun"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_TIME; } }

    protected override Datum MakeAggregateInstance() { return new QueueThreadSpins(0); }
  }

  /// <summary>
  /// How many times queue slice was processed
  /// </summary>
  [Serializable]
  [Arow("C7CA1C29-78AD-44AE-930C-F44F3D58E615")]
  [BSONSerializable("9E9F5A61-35E6-40DC-AF37-BFF8CA2AB034")]
  public class ProcessOneQueueCount : TodoQueueLongGauge
  {
    public ProcessOneQueueCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many times queue slice was processed"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_TIME; } }

    protected override Datum MakeAggregateInstance() { return new ProcessOneQueueCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo instances got merged
  /// </summary>
  [Serializable]
  [Arow("AD47A075-5551-435A-8AA9-2EF2DEBC201D")]
  [BSONSerializable("C2DBB2EB-A9AA-49FD-B434-891837AD1E12")]
  public class MergedTodoCount : TodoQueueLongGauge
  {
    public MergedTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo instances got merged"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new MergedTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo messages got fetched from store
  /// </summary>
  [Serializable]
  [Arow("98EB8EDD-63F0-4D6A-95ED-EDD7DEB9B9A0")]
  [BSONSerializable("162AEBA6-F5B0-4A76-9DF7-F57C43D3D6FB")]
  public class FetchedTodoCount : TodoQueueLongGauge
  {
    public FetchedTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo messages got fetched from store"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new FetchedTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo messages got processed
  /// </summary>
  [Serializable]
  [Arow("C0330BF7-A678-4FBD-94D8-E94D5E195050")]
  [BSONSerializable("B88C36FC-E0EA-4BA9-BA6D-4AFB139DEDD4")]
  public class ProcessedTodoCount : TodoQueueLongGauge
  {
    public ProcessedTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo messages got processed"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new ProcessedTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo got put into the store
  /// </summary>
  [Serializable]
  [Arow("8DDA819F-6756-4B67-A8B6-0AD8F2CA5283")]
  [BSONSerializable("559D9D5C-7671-4F4F-8A30-189DAA44D2B0")]
  public class PutTodoCount : TodoQueueLongGauge
  {
    public PutTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo got put into the store"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new PutTodoCount(this.Source, 0); }
  }


  /// <summary>
  /// How many Todo instances were submitted more than once
  /// </summary>
  [Serializable]
  [Arow("6D667B4D-34A8-474E-8C48-4A2283643072")]
  [BSONSerializable("53BA67B9-115E-4CDF-9B58-00854C252AEF")]
  public class TodoDuplicationCount : TodoQueueLongGauge
  {
    public TodoDuplicationCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo instances were submitted more than once"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new TodoDuplicationCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo got updated in the store
  /// </summary>
  [Serializable]
  [Arow("291228EA-D8CA-4FA1-AD64-160A20C44771")]
  [BSONSerializable("1EBC5BEB-51D1-40FA-AD26-BBD9DAB52FDF")]
  public class UpdateTodoCount : TodoQueueLongGauge
  {
    public UpdateTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo got updated in the store"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new UpdateTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo were completed regardless of OK or Error
  /// </summary>
  [Serializable]
  [Arow("16271023-A658-4B30-AFB2-482F8C39D182")]
  [BSONSerializable("1CCA58EB-34B3-4698-85F5-0ED664F78A98")]
  public class CompletedTodoCount : TodoQueueLongGauge
  {
    public CompletedTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo were completed regardless of OK or Error"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new CompletedTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo were completed OK
  /// </summary>
  [Serializable]
  [Arow("F929669C-9BA7-4BDD-97C8-012CCE951D8D")]
  [BSONSerializable("790E14AC-BD70-4268-BDAB-5E56B1E2DC39")]
  public class CompletedOkTodoCount : TodoQueueLongGauge
  {
    public CompletedOkTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo were completed OK"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new CompletedOkTodoCount(this.Source, 0); }
  }

  /// <summary>
  /// How many Todo were completed with Error
  /// </summary>
  [Serializable]
  [Arow("F2584025-AA65-4B53-BEFD-E05A2E953D79")]
  [BSONSerializable("04D233B2-CA69-45A6-9FEC-6E7B9875222D")]
  public class CompletedErrorTodoCount : TodoQueueLongGauge, IErrorInstrument
  {
    public CompletedErrorTodoCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many Todo were completed with Error"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new CompletedErrorTodoCount(this.Source, 0); }
  }


  /// <summary>
  /// How many times queue processing error happened
  /// </summary>
  [Serializable]
  [Arow("1919D75D-6377-4037-9227-B75B5BC5CB98")]
  [BSONSerializable("1FA8D0D3-577B-46C1-A86D-864CDBC7EBBA")]
  public class QueueOperationErrorCount : TodoQueueLongGauge, IErrorInstrument
  {
    public QueueOperationErrorCount(string queue, long value) : base(queue, value) { }

    public override string Description { get { return "How many times queue processing error happened"; } }

    public override string ValueUnitName { get { return CoreConsts.UNIT_NAME_ERROR; } }

    protected override Datum MakeAggregateInstance() { return new QueueOperationErrorCount(this.Source, 0); }
  }
}
