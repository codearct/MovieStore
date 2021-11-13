
export const ADD_TO_CART = "ADD_TO_CART"
export const REMOVE_FROM_CART = "REMOVE_FROM_CART"

export function addToCart(movie) {
    return {
        type: ADD_TO_CART,
        payload: movie
    }
}

export function removeFromCart(movie) {
    return {
        type: REMOVE_FROM_CART,
        payload: movie
    }
}