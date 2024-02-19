import { useState } from 'react';
import './App.css';
import { TextareaAutosize, Button, Typography, Container, Card, CardContent } from '@mui/material';
import { green, red } from '@mui/material/colors';

function App() {
    const [text, setText] = useState('');
    const [result, setResult] = useState();

    const checkSpelling = async () => {
        const params = new URLSearchParams({ text });
        const response = await fetch(`spell-check?${params}`);
        const data = await response.json();
        setResult(data);
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" gutterBottom>
                Spell Checker
            </Typography>
            <div style={{ marginBottom: '16px', paddingRight: '16px' }}>
                <TextareaAutosize
                    aria-label="Enter text"
                    minRows={5}
                    value={text}
                    onChange={e => setText(e.target.value)}
                    style={{ width: '100%', resize: 'vertical', padding: '8px' }}
                />
            </div>
            <Button variant="contained" onClick={checkSpelling} fullWidth>
                Check Spelling
            </Button>
            {result && <Card variant="outlined" style={{ marginTop: '16px', width: '100%' }}>
                <CardContent>
                    <Typography variant="body2" color={result.isValid ? green[500] : red[500]}>
                        {result.feedback}
                    </Typography>
                </CardContent>
            </Card>}
        </Container>
    );
}

export default App;