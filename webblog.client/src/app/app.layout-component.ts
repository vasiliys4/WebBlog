import { Component, HostListener, AfterViewInit, ElementRef, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './app.layout-component.html',
  styleUrls: ['./app.layout-component.scss']
})
export class LayoutComponent implements OnInit, AfterViewInit {
  isMobile = false;
  isAuthenticated = false;
  isDarkMode = false;
  mobileMenuOpen = false;

  constructor(private el: ElementRef) {
    this.checkScreenSize();
  }

  ngOnInit() {
    // Загружаем тему из localStorage или из системных настроек
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme) {
      this.isDarkMode = savedTheme === 'dark';
    } else {
      this.isDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    }
    this.applyTheme();

    // Реакция на смену системной темы
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
      if (!localStorage.getItem('theme')) { // если пользователь не выбрал явно
        this.isDarkMode = e.matches;
        this.applyTheme();
      }
    });

    // Проверка авторизации по localStorage (JWT)
    this.isAuthenticated = !!localStorage.getItem('authToken');
  }

  toggleTheme() {
    this.isDarkMode = !this.isDarkMode;
    this.applyTheme();
    localStorage.setItem('theme', this.isDarkMode ? 'dark' : 'light');
  }

  toggleMobileMenu() {
    this.mobileMenuOpen = !this.mobileMenuOpen;
  }

  closeMobileMenu() {
    this.mobileMenuOpen = false;
  }

  applyTheme() {
    document.documentElement.setAttribute('data-theme', this.isDarkMode ? 'dark' : 'light');
  }

  @HostListener('window:resize')
  checkScreenSize() {
    this.isMobile = window.innerWidth < 768;
    if (!this.isMobile) this.mobileMenuOpen = false;
  }

  login(token: string) {
    localStorage.setItem('authToken', token);
    this.isAuthenticated = true;
  }

  logout() {
    localStorage.removeItem('authToken');
    this.isAuthenticated = false;
  }

  ngAfterViewInit() {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            entry.target.classList.add('fade-in-up');
            observer.unobserve(entry.target);
          }
        });
      },
      { threshold: 0.1 }
    );

    const elements = this.el.nativeElement.querySelectorAll('.fade-element');
    elements.forEach((el: Element) => observer.observe(el));
  }
}

