import { Component, HostListener, AfterViewInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './app.layout-component.html',
  styleUrls: ['./app.layout-component.scss']
})
export class LayoutComponent implements AfterViewInit {
  isMobile = false;
  isAuthenticated = false; // заменить логикой авторизации
  isDarkMode = false;
  mobileMenuOpen = false;

  constructor(private el: ElementRef) {
    this.checkScreenSize();
  }

  ngOnInit() {
    // Автоподстройка под системную тему
    this.isDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    this.applyTheme();

    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
      this.isDarkMode = e.matches;
      this.applyTheme();
    });
  }

  toggleTheme() {
    const currentTheme = document.documentElement.getAttribute('data-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    document.documentElement.setAttribute('data-theme', newTheme);
    localStorage.setItem('theme', newTheme);
  }

  toggleMobileMenu() {
    this.mobileMenuOpen = !this.mobileMenuOpen;
  }

  applyTheme() {
    const body = document.body;
    if (this.isDarkMode) {
      body.classList.add('dark-mode');
    } else {
      body.classList.remove('dark-mode');
    }
  }

  @HostListener('window:resize')
  checkScreenSize() {
    this.isMobile = window.innerWidth < 768;
  }

  login() {
    this.isAuthenticated = true; // пример
  }

  logout() {
    this.isAuthenticated = false; // пример
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

