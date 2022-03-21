namespace Querist
{
    public class ValidatedInput<T>
    {
        public ValidatedInput(Func<T?, bool> validate, Action<T?> onInputInvalid, IInputBase<T> input)
        {
            Validate = validate;
            OnInputInvalid = onInputInvalid;
            Input = input;
        }

        public Func<T?,bool> Validate { get; set; }
        public Action<T?> OnInputInvalid { get; set; }
        public IInputBase<T> Input { get; set; }

        public T? Get()
        {
        redo:
            var value = Input.Get();
            if (Validate(value)) return value;
            else OnInputInvalid(value);
            goto redo;
        }

    }
}