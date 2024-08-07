import React, { useEffect, useState } from 'react';

function App() {
    const [message, setMessage] = useState('');
    const [buttonClicked, setButtonClicked] = useState(false);

    useEffect(() => {
        fetch('https://localhost:7024/values')
            .then(response => response.json())
            .then(data => setMessage(data.message))
            .catch(error => console.error('Error fetching data:', error));
    }, []);

    const handleClick = () => {
        setButtonClicked(true);
    };

    return (
        <div className="App">
            <header className="App-header">
                <h1>{message ? message : 'Loading...'}</h1>
                <button onClick={handleClick}>Click Me</button>
                {buttonClicked && <h2>Button was clicked!</h2>}
            </header>
        </div>
    );
}

export default App;