function DX_CheckBox(options) {
  $(options.Target).dxCheckBox({
    value: false,
    name: options.Name,
    text: options.Text
  });
}

export { DX_CheckBox };
