export interface Form {
    numberOfPasswords: number;
    passwordLength: number;
    upperCase: number;
    digits: number;
    symbols: number;
    excludeSimilar: boolean;
    excludeAmbigous: boolean;
}