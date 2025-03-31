import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
import joblib

# Fungsi untuk melatih model
def train_model():
    # Membaca data dari file Excel
    df = pd.read_excel('HousePrice.xlsx')
    
    # Misalnya, kita punya kolom 'feature1', 'feature2' sebagai fitur, dan 'target' sebagai target
    X = df[['Square_Footage', 'Num_Bedrooms', 'Num_Bathrooms', 'Year_Built', 'Lot_Size', 'Garage_Size', 'Neighborhood_Quality']]
    y = df['House_Price']
    
    # Bagi data menjadi set pelatihan dan pengujian
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
    
    # Buat model regresi linier
    model = LinearRegression()
    model.fit(X_train, y_train)
    
    # Simpan model ke file
    joblib.dump(model, 'model.pkl')
    
    print("Model telah dilatih dan disimpan!")

# Jalankan pelatihan model
train_model()
