import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacteristicTypeListComponent } from './characteristic-type-list.component';

describe('CharacteristicTypeListComponent', () => {
  let component: CharacteristicTypeListComponent;
  let fixture: ComponentFixture<CharacteristicTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CharacteristicTypeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacteristicTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
