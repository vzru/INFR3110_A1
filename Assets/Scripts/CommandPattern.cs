using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandSpace
{
    public class CommandPattern : MonoBehaviour
    {
        public static List<Command> completedCommands = new List<Command>();
        public static List<Command> undoneCommands = new List<Command>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public abstract class Command
    {
        public float newValue = 0;
        public float oldValue = 0;

        public abstract void Execute(Command command, float value);

        public virtual void Undo() { }

        public virtual void Redo() { }
    }

    public class ChangeValue : Command
    {
        public override void Execute(Command command, float value)
        {
            // Do something

            CommandPattern.completedCommands.Add(command);
        }

        public override void Undo()
        {
            // Reverse Command
        }

        public override void Redo()
        {
            // Redo Command
        }
    }

    public class EmptyCommand : Command
    {
        public override void Execute(Command command, float value)
        {
            // Do Nothing
        }
    }

    public class UndoCommand : Command
    {
        public override void Execute(Command command, float value)
        {
            int size = CommandPattern.completedCommands.Count;
            if (size > 0)
            {
                Command currentCommand = CommandPattern.completedCommands[size - 1];

                currentCommand.Undo();

                CommandPattern.completedCommands.RemoveAt(size - 1);

                CommandPattern.undoneCommands.Add(currentCommand);
            }
        }
    }

    public class RedoCommand : Command
    {
        public override void Execute(Command command, float value)
        {
            int size = CommandPattern.undoneCommands.Count;
            if (size > 0)
            {
                Command currentCommand = CommandPattern.undoneCommands[size - 1];

                currentCommand.Redo();

                CommandPattern.undoneCommands.RemoveAt(size - 1);

                CommandPattern.completedCommands.Add(currentCommand);
            }
        }
    }
}