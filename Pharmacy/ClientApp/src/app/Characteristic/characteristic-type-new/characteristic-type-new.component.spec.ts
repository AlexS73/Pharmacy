import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacteristicTypeNewComponent } from './characteristic-type-new.component';

describe('CharacteristicTypeNewComponent', () => {
  let component: CharacteristicTypeNewComponent;
  let fixture: ComponentFixture<CharacteristicTypeNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharacteristicTypeNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacteristicTypeNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
