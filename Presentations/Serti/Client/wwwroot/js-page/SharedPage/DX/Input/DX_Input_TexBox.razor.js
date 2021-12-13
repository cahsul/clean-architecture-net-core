function DX_Input_TexBox(options) {
  console.log(options.Validator);
  $(options.Target).dxTextBox({
    name: options.Name,
    value: options.Value,
    label: options.Label,
    labelMode: "floating",
    placeholder: options.Placeholder,
    showClearButton: true
  }).dxValidator({
    validationRules: options.Validator //validationRules: [
    //    //{
    //    //    type: 'required',
    //    //}
    //],

  });
}

export { DX_Input_TexBox };
