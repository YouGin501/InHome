import { Component, Input, OnInit, forwardRef } from '@angular/core';
import {
  ControlValueAccessor,
  NG_VALUE_ACCESSOR,
  ValidationErrors,
} from '@angular/forms';

@Component({
  selector: 'app-default-input',
  templateUrl: './default-input.component.html',
  styleUrls: ['./default-input.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DefaultInputComponent),
      multi: true,
    },
  ],
})
export class DefaultInputComponent implements ControlValueAccessor, OnInit {
  @Input() inputType: string = 'text';
  @Input() labelText: string = '';
  @Input() errors!: ValidationErrors | null;
  @Input() dirty: boolean = false;
  @Input() touched: boolean = false;
  @Input() errorMessage: string = '';
  @Input() submitAttempt: boolean = false;

  disabled = false;
  value: any = '';

  private static id: number = 0;
  componentId: number = 0;

  onChange: any = () => {};
  onTouched: any = () => {};

  constructor() {}

  ngOnInit(): void {
    this.componentId = ++DefaultInputComponent.id;
  }

  writeValue(obj: any): void {
    this.value = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  setValue(value: any) {
    this.value = value;
    this.onChange(value);
  }
  focusOut() {
    this.onTouched();
  }
}
