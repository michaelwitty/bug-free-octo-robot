import React from 'react';
import Header from './Header';
import Footer from './Footer';

function Layout({ children }) {
	return (
        <>
        <Header />
        <main role="main" className="content">
            <div className="container">
                {children}
            </div>
        </main>
        <Footer />
        </>
	);
}
export default Layout