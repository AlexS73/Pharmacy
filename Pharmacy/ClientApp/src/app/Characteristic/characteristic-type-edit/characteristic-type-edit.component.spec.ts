import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacteristicTypeEditComponent } from './characteristic-type-edit.component';

describe('CharacteristicTypeEditComponent', () => {
  let component: CharacteristicTypeEditComponent;
  let fixture: ComponentFixture<CharacteristicTypeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharacteristicTypeEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacteristicTypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
