namespace Espetaculos.Domain.Utils {
    public static class CommanValidations {
        public static bool IsNull<T>(this T value) {
            return value == null;
        }
    }
}