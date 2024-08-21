document.addEventListener('DOMContentLoaded', function() {
    // Add smooth scrolling to all links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            document.querySelector(this.getAttribute('href')).scrollIntoView({
                behavior: 'smooth'
            });
        });
    });

    // Add a simple fade-in animation to the info cards
    const infoCards = document.querySelectorAll('.info-card');
    infoCards.forEach((card, index) => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
        
        setTimeout(() => {
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, 200 * (index + 1));
    });

    // Add a simple fade-in animation to the featured exhibits
    const exhibits = document.querySelectorAll('.exhibit-card');
    exhibits.forEach((exhibit, index) => {
        exhibit.style.opacity = '0';
        exhibit.style.transform = 'translateY(20px)';
        exhibit.style.transition = 'opacity 0.5s ease, transform 0.5s ease';
        
        setTimeout(() => {
            exhibit.style.opacity = '1';
            exhibit.style.transform = 'translateY(0)';
        }, 300 * (index + 1));
    });
});
