
document.addEventListener("DOMContentLoaded", () => {

    const elements = [
        document.querySelector('.promo-title'),
        document.querySelector('.promo-mission'),
        ...document.querySelectorAll('#banner p:not(.promo-title):not(.promo-mission)'),
        document.querySelector('.btn-tutorial')
    ];

  
    elements.forEach((el, index) => {
        if (el) { 
            setTimeout(() => {
                el.classList.add('visible');
            }, index * 400);
        }
    });

  
    const bannerImage = document.querySelector('.banner-img');
    if (bannerImage) {
        setTimeout(() => {
            bannerImage.classList.add('visible');
        }, 1000); // image comes after text
    }
});

