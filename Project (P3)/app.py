from flask import Flask, request, render_template
import pandas as pd
import joblib

app = Flask(__name__)

# Load model prediksi
model = joblib.load('model.pkl')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/predict', methods=['POST'])
def predict():
    # Ambil data dari form yang diisi pengguna
    feature1 = float(request.form['feature1'])
    feature2 = float(request.form['feature2'])
    
    # Membuat prediksi berdasarkan data yang diinputkan
    data_baru = pd.DataFrame([[feature1, feature2]], columns=['feature1', 'feature2'])
    prediksi = model.predict(data_baru)
    
    return render_template('index.html', prediction=prediksi[0])

if __name__ == '__main__':
    app.run(debug=True)
