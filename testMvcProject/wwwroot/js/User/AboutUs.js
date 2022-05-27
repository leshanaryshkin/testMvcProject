"use strict"

window.onload = function () {
	const parallax = document.querySelector('.parallax');

	if (parallax) {
		const content = document.querySelector('.parallax__container');
		const clouds = document.querySelector('.images-parallax__clouds');
		const mountains = document.querySelector('.images-parallax__mountains');
		const human = document.querySelector('.images-parallax__human');

		const forClouds = 100;
		const forMountains = 140;
		const forHuman = 90;

		const speed = 5;

		let positionX = 0, positionY = 0;
		let coordXprocent = 0, coordYprocent = 0;

		function setMouseParallaxStyle() {
			const distX = coordXprocent - positionX;
			const distY = coordYprocent - positionY;

			positionX = positionX + (distX * speed);
			positionY = positionY + (distY * speed);

			clouds.style.cssText = `transform: translate(${positionX / forClouds}%,${positionY / forClouds}%);`;
			mountains.style.cssText = `transform: translate(${positionX / forMountains}%,${positionY / forMountains
				}%);`;
			human.style.cssText = `transform: translate(${positionX / forHuman}%,${positionY / forHuman}%);`;

			requestAnimationFrame(setMouseParallaxStyle);
		}
		setMouseParallaxStyle();

		parallax.addEventListener("mousemove", function (e) {

			const parallaxWidth = parallax.offsetWidth;
			const parallaxHeight = parallax.offsetHeight;

			const coordX = e.pageX - parallaxWidth / 2;
			const coordY = e.pageY - parallaxHeight / 2;

			coordXprocent = coordX / parallaxWidth * 100;
			coordYprocent = coordY / parallaxHeight * 100;
		});

		let thresholdSets = [];
		for (let i = 0; i <= 1.0; i += 0.005) {
			thresholdSets.push(i);
		}
		const callbaсk = function (entries, obsercer) {
			const scrollTopProcent = window.pageYOffset / parallax.offsetHeight * 100;
			setParallaxItemStyle(scrollTopProcent);
		};

		const observer = new IntersectionObserver(callbaсk, {
			threshold: thresholdSets
		});

		observer.observe(document.querySelector('.content'));

		function setParallaxItemStyle(scrollTopProcent) {
			content.style.cssText = `transform: translate(0%,-${scrollTopProcent / 3}%);`;
			mountains.parentElement.style.cssText = `transform: translate(0%,-${scrollTopProcent / 2}%);`;
			human.parentElement.style.cssText = `transform: translate(0%,-${scrollTopProcent / 1}%);`;
		}
	}
}