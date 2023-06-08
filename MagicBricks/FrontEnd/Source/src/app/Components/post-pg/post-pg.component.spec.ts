import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostPGComponent } from './post-pg.component';

describe('PostPGComponent', () => {
  let component: PostPGComponent;
  let fixture: ComponentFixture<PostPGComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostPGComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostPGComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
